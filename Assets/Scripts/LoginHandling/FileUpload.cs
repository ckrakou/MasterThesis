using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.Networking;
using System.IO;
using System;

public class FileUpload : MonoBehaviour
{
    public bool debugging = false;
    public string[] FailureMessages;
    public GameObject Button;
    //public GameObject WelcomeText;
    public GameObject ResponseText;

    private Fader fader;


#if UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern void ImageUploaderInit();
#endif
    static string s_dataUrlPrefix = "data:image/png;base64,";

    private byte[] masterFile = new byte[0];
    private GameUnlocker unlocker;
    private SQLDatabaseConnection db;



    private void Start()
    {
        db = GetComponent<SQLDatabaseConnection>();
        unlocker = GetComponent<GameUnlocker>();
        fader = GetComponent<Fader>();
        TextAsset bindata = Resources.Load("MasterFile") as TextAsset;
        masterFile = bindata.bytes;

        if (!debugging)
        {
#if UNITY_WEBGL
            ImageUploaderInit();
#endif
        }
    }

    // Get the uploaded file. If we're debugging, change the test cube. If we're 
    // live, load the main scene. 
    IEnumerator EnterFile(string url)
    {
        UnityWebRequest file = UnityWebRequest.Get(url);
        yield return file.SendWebRequest();
        byte[] rawFile = file.downloadHandler.data;

        // DATABASE WRITING
        if (CheckFile(rawFile))
        {
            //WelcomeText.SetActive(true);
            ResponseText.SetActive(false);
            Button.GetComponent<Button>().enabled = false;
            if (debugging)
                Debug.Log("FileUpload: File identified successfully");

            unlocker.UnlockMainScene();
        }
        else
        {
            if (debugging)
                Debug.Log("FileUpload: File does not match");

            if(!debugging)
                db.RegisterFailedLogin();

            //Button.SetActive(false);
            //WelcomeText.SetActive(false);
            ResponseText.SetActive(true);

            StartCoroutine( fader.FadeResponse(FailureMessages[UnityEngine.Random.Range((int)0, FailureMessages.Length - 1)]));

            //ResponseText.GetComponentInChildren<Text>().text = FailureMessages[UnityEngine.Random.Range((int)0, FailureMessages.Length - 1)];
        }

    }

    // Compares master file to uploaded file, byte by byte
    private bool CheckFile(byte[] rawFile)
    {
        if (rawFile.Length != masterFile.Length)
            return false;

        for (int i = 0; i < masterFile.Length; i++)
        {
            if (masterFile[i] != rawFile[i])
                return false;
        }

        return true;
    }

    void FileSelected(string url)
    {
        if (debugging)
            Debug.Log("FileUpload: File succesfully selected");
        StartCoroutine(EnterFile(url));
    }

    public void OnButtonPointerDown()
    {

        if (debugging)
            Debug.Log(GetType() + ": Click Registrered");

        if (GetComponent<IdentityTester>().KeyFound == false)
        {



#if UNITY_EDITOR
            string path = UnityEditor.EditorUtility.OpenFilePanel("Open file", "", "");
            if (!System.String.IsNullOrEmpty(path))
                FileSelected("file:///" + path);
#else
        //ImageUploaderCaptureClick ();

#endif
        }
        
    }
}

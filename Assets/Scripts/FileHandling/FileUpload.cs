using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Networking;
using System.IO;
using System;

public class FileUpload : MonoBehaviour
{
    public bool debugging = false;
    public GameObject TestCube;

    [DllImport("__Internal")]
    private static extern void ImageUploaderInit();

    static string s_dataUrlPrefix = "data:image/png;base64,";

    private byte[] masterFile = new byte[0];
    private GameUnlocker unlocker;

    private void Start()
    {
        unlocker = GetComponent<GameUnlocker>();
        TextAsset bindata = Resources.Load("MasterFile") as TextAsset;
        masterFile = bindata.bytes;

        if (!debugging)
        {
            TestCube.SetActive(false);
            ImageUploaderInit();
        }
    }

    // Get the uploaded file. If we're debugging, change the test cube. If we're 
    // live, load the main scene. 
    IEnumerator EnterFile(string url)
    {
        UnityWebRequest file = UnityWebRequest.Get(url);
        yield return file.SendWebRequest();
        byte[] rawFile = file.downloadHandler.data;


        if (CheckFile(rawFile))
        {
            if (debugging)
            {
                Debug.Log("FileUpload: File identified successfully");
                TestCube.GetComponent<Renderer>().material.color = Color.red;
            }
            else
                unlocker.UnlockMainScene();
        }
        else
        {
            if (debugging)
                Debug.Log("FileUpload: File does not match");
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

#if UNITY_EDITOR
        string path = UnityEditor.EditorUtility.OpenFilePanel("Open file", "", "");
        if (!System.String.IsNullOrEmpty(path))
            FileSelected("file:///" + path);
#else
        //ImageUploaderCaptureClick ();

#endif

    }
}

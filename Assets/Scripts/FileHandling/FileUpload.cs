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

    [DllImport("__Internal")]
    private static extern void ImageUploaderCaptureClick();

    private byte[] masterFile = new byte[0];
    private GameUnlocker unlocker;

    private void Start()
    {
        unlocker = GetComponent<GameUnlocker>();
        TextAsset bindata = Resources.Load("MasterFile") as TextAsset;
        masterFile = bindata.bytes;
    }
    /*
    IEnumerator LoadTexture(string url)
    {
        WWW image = new WWW(url);
        yield return image;
        Texture2D texture = new Texture2D(1, 1);
        image.LoadImageIntoTexture(texture);
        Debug.Log("Loaded image size: " + texture.width + "x" + texture.height);
    }
    */
    IEnumerator EnterFile(string url)
    {
        UnityWebRequest file = UnityWebRequest.Get(url);
        yield return file.SendWebRequest();
        byte[] rawFile = file.downloadHandler.data;

        if (debugging)
        {
            if (CheckFile(rawFile))
                Debug.Log("FileUpload: File matches");
            else
                Debug.Log("FileUpload: File does not match");
        }

        if (CheckFile(rawFile))
            unlocker.UnlockMainScene();
    }

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
        string path = UnityEditor.EditorUtility.OpenFilePanel("Open image", "", "jpg,png,bmp");
        if (!System.String.IsNullOrEmpty(path))
            FileSelected("file:///" + path);
#else
        ImageUploaderCaptureClick ();
#endif
    }
}

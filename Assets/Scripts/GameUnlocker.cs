using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUnlocker : MonoBehaviour
{
    public string SceneToLoad;

    public void UnlockMainScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}

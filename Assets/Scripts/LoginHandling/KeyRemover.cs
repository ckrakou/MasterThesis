using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRemover : MonoBehaviour
{
    public void RemoveKey()
    {
        string Key = GetComponent<IdentityTester>().Key;
        PlayerPrefs.DeleteKey(Key);
    }
}

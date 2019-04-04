using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndLog : MonoBehaviour
{
    public GameObject CartoonTree;
    public GameObject GhostLog;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(BlinkingTree());
    }

    // Update is called once per frame
  

    IEnumerator BlinkingTree(){

       for(int i = 0; i < 15; i++){
        yield return new WaitForSeconds(Random.Range(0.03f,0.3f));  
        CartoonTree.gameObject.SetActive(true);
        GhostLog.gameObject.SetActive(false);

         yield return new WaitForSeconds(Random.Range(0.03f,0.3f));  
          CartoonTree.gameObject.SetActive(false);
        GhostLog.gameObject.SetActive(true);
       }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawn : MonoBehaviour
{
 public GameObject[] WorldMonuments;


    private Vector3 placeToSpawn;    


	// Use this for initialization
	void Start () {

    for(int i = 0; i < WorldMonuments.Length; i++){
      
        placeToSpawn = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
	Instantiate(WorldMonuments[i], placeToSpawn, Quaternion.identity);
        
        }
	}
}

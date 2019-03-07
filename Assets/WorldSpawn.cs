using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawn : MonoBehaviour
{
 public GameObject[] WorldMonuments;

 public GameObject DatamoshCubes;


    public int MinDatamoshColliders = 25;
    public int MaxDatamoshColliders = 50;

    private Vector3 placeToSpawn;    


	// Use this for initialization
	void Awake () {

    for(int i = 0; i < WorldMonuments.Length; i++){
      //spawn world monuments at random
        placeToSpawn = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
	Instantiate(WorldMonuments[i], placeToSpawn, Quaternion.identity);
        
        }

        //spawn datamosh colliders
        int NumberOfDatamosh = Random.Range(MinDatamoshColliders,MaxDatamoshColliders);
        for(int i = 0; i < NumberOfDatamosh; i++){
      
        placeToSpawn = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
	Instantiate(DatamoshCubes, placeToSpawn, Quaternion.identity);
        
        }



	}
}

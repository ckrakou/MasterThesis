using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawn : MonoBehaviour
{
 public GameObject[] WorldMonuments;

 public GameObject DatamoshCubes;
 public GameObject AnalogGlitchCubes;

 public GameObject teleporterCubes;

 public GameObject Clock;


    public int MinDatamoshColliders = 25;
    public int MaxDatamoshColliders = 50;


public int MinAnalogGlitchColliders = 25;
    public int MaxAnalogGlitchColliders = 50;

    public int MinTeleportColliders = 1;
   public int  MaxTeleportColliders = 4;

    private Vector3 placeToSpawn;    


	// Use this for initialization
	void Awake () {
        Cursor.visible = false;
    for(int i = 0; i < WorldMonuments.Length; i++){
      //spawn world monuments at random
       int ramdomMonumentRotationY=Random.Range(-180,180);
      Quaternion MonumenrSpawnRotation = Quaternion.Euler(0,ramdomMonumentRotationY,0);
        placeToSpawn = new Vector3(Random.Range(-100, 100), 0, Random.Range(-300, 300));
	Instantiate(WorldMonuments[i], placeToSpawn, MonumenrSpawnRotation);
        
        }
             
        //spawn datamosh colliders
        int NumberOfDatamosh = Random.Range(MinDatamoshColliders,MaxDatamoshColliders);
        for(int i = 0; i < NumberOfDatamosh; i++){
      
        placeToSpawn = new Vector3(Random.Range(-500, 500), 0, Random.Range(-400, 400));
	Instantiate(DatamoshCubes, placeToSpawn, Quaternion.identity);
        
        }

         //spawn teleport colliders
        int NumberOfTeleport = Random.Range(MinTeleportColliders,MaxTeleportColliders);
        for(int i = 0; i < NumberOfTeleport; i++){
      
        placeToSpawn = new Vector3(Random.Range(-300, 300), 0, Random.Range(-300, 300));
	Instantiate(teleporterCubes, placeToSpawn, Quaternion.identity);
        }

        //spawn AnalogGlitch colliders
        int NumberOfAnalogGlitch = Random.Range(MinAnalogGlitchColliders,MaxAnalogGlitchColliders);
        for(int i = 0; i < NumberOfAnalogGlitch; i++){
      
        placeToSpawn = new Vector3(Random.Range(-500, 500), 0, Random.Range(-400, 400));
	Instantiate(AnalogGlitchCubes, placeToSpawn, Quaternion.identity);
        }

         //spawn alot of clocks
          int NumberOfClocks = Random.Range(40,60);
        for(int i = 0; i < NumberOfClocks; i++){
      
        placeToSpawn = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
        int ramdomClockRotationY=Random.Range(-180,180);
         Quaternion ClockSpawnRotation = Quaternion.Euler(0,ramdomClockRotationY,0);
	GameObject newObject = Instantiate(Clock, placeToSpawn, ClockSpawnRotation) as GameObject;
        int randonSize = Random.Range(4, 10);
        newObject.transform.localScale = new Vector3(randonSize, randonSize+Random.Range(0,4), randonSize);
        }
        //Set starting skybox exposure
        RenderSettings.skybox.SetFloat ("_Exposure",0.55f);


	}

        public void SpawnDatamoshCubes(int NumberOfCubes){

        for(int i = 0; i < NumberOfCubes; i++){
      
        placeToSpawn = new Vector3(Random.Range(-400, 400), 0, Random.Range(-400, 400));
	Instantiate(DatamoshCubes, placeToSpawn, Quaternion.identity);
        
        }
        Debug.Log("spawned "+NumberOfCubes+" datamosh cubes");
        }


        public void spawnAnalogGlitchCubes(int NumberOfCubes){
        for(int i = 0; i < NumberOfCubes; i++){
        placeToSpawn = new Vector3(Random.Range(-400, 400), 0, Random.Range(-400, 400));
	Instantiate(AnalogGlitchCubes, placeToSpawn, Quaternion.identity);
                }
                Debug.Log("spawned "+NumberOfCubes+" analog-glitch cubes");
        }

        public void TurnUpSkyboxExposure(float SetNewExposure){

             StartCoroutine(glitchSkybox(SetNewExposure));

        }
        IEnumerator glitchSkybox(float newExposure){
        float OldExposure = RenderSettings.skybox.GetFloat ("_Exposure");

        yield return new WaitForSeconds(Random.Range(0.05f,0.5f));   
        RenderSettings.skybox.SetFloat ("_Exposure",newExposure);

         yield return new WaitForSeconds(Random.Range(0.05f,0.5f));   
        RenderSettings.skybox.SetFloat ("_Exposure",OldExposure);
        
        yield return new WaitForSeconds(Random.Range(0.05f,0.5f));   
        RenderSettings.skybox.SetFloat ("_Exposure",newExposure);

         yield return new WaitForSeconds(Random.Range(0.05f,0.5f));   
        RenderSettings.skybox.SetFloat ("_Exposure",OldExposure);

           yield return new WaitForSeconds(Random.Range(0.05f,0.5f));   
        RenderSettings.skybox.SetFloat ("_Exposure",newExposure);

         yield return new WaitForSeconds(Random.Range(0.05f,0.5f));   
        RenderSettings.skybox.SetFloat ("_Exposure",OldExposure);
           yield return new WaitForSeconds(Random.Range(0.05f,0.5f));   
        
        RenderSettings.skybox.SetFloat ("_Exposure",newExposure);

         yield return new WaitForSeconds(Random.Range(0.05f,0.5f));   
        RenderSettings.skybox.SetFloat ("_Exposure",OldExposure);

           yield return new WaitForSeconds(Random.Range(0.05f,0.5f));   
        RenderSettings.skybox.SetFloat ("_Exposure",newExposure);

         yield return new WaitForSeconds(Random.Range(0.05f,0.5f));   
        RenderSettings.skybox.SetFloat ("_Exposure",OldExposure);
          
           yield return new WaitForSeconds(Random.Range(0.05f,0.5f));   
        RenderSettings.skybox.SetFloat ("_Exposure",newExposure);

   

        }

}

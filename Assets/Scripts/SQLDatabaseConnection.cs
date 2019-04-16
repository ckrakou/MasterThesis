using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SQLDatabaseConnection : MonoBehaviour
{
    private const string V = "playtime: ";

    public bool Debugging;
    public GameObject Player;
     
    public GameObject DeadPlayers;
    
    public WorldTimer worldTimer;

    [Header("Tree Settings")]
    public Vector3 MaxSize = new Vector3(3, 3, 3);

    private float playtime;

    void Start()
    {
    
        if (Debugging)
        {


            //RegisterSucessfullLogin();
            //Debug.Log("registration started");
            //RegisterWhenPlayerDies();
            //RegisterFailedLogin();

        }
        RetriveDeadCoordinates();
    }
    void Update()
    {
        playtime = playtime + Time.deltaTime;

    }
    public void RegisterSucessfullLogin()
    {
        StartCoroutine(RegisterPlayerLogin());

    }
    public void RegisterFailedLogin()
    {
        StartCoroutine(RegisterPlayerLoginFail());

    }
    public void RegisterWhenPlayerDies()
    {
        StartCoroutine(RegisterPlayerDeath());

    }

    public void RetriveDeadCoordinates()
    {
        StartCoroutine(RetriveDeadSpawnPointsFromWeb());

    }

    IEnumerator RegisterPlayerLogin()
    {
        //create webform
        WWWForm registerForm = new WWWForm();
        registerForm.AddField("is_player_logged_in", "yes");

        //call php script
        //  WWW www = new WWW("http://hawaiipizza.dk/stuff/registerlogin.php", registerForm);


        using (UnityWebRequest www = UnityWebRequest.Post("http://hawaiipizza.dk/stuff/registerlogin.php", registerForm))
        {
            yield return www.SendWebRequest();

            //Debug.Log(www.downloadHandler.text);

            if (www.downloadHandler.text == "0: Sucess!")
            {
                //Debug.Log("logintime sucessfully stored in database");

            }
        }
    }
    IEnumerator RegisterPlayerLoginFail()
    {
        //create webform
        WWWForm FailForm = new WWWForm();
        FailForm.AddField("is_player_logged_in", "no");

        using (UnityWebRequest www = UnityWebRequest.Post("http://hawaiipizza.dk/stuff/registerloginfail.php", FailForm))
        {
            yield return www.SendWebRequest();

            //Debug.Log(www.downloadHandler.text);

            if (www.downloadHandler.text == "0: Sucess!")
            {
               // Debug.Log("failed login sucessfully stored in database");

            }
        }
    }


    IEnumerator RegisterPlayerDeath()
    {
        //create webform
        WWWForm DeathForm = new WWWForm();


        DeathForm.AddField("x", Player.transform.position.x.ToString());
        DeathForm.AddField("y", Player.transform.position.y.ToString());
        DeathForm.AddField("z", Player.transform.position.z.ToString());
        DeathForm.AddField("playtime", Mathf.RoundToInt(playtime));
        //DeathForm.AddField("plytime", playtime.ToString());


        //call php script
        //  WWW www = new WWW("http://hawaiipizza.dk/stuff/registerlogin.php", registerForm);


        using (UnityWebRequest www = UnityWebRequest.Post("http://hawaiipizza.dk/stuff/deadplayers.php", DeathForm))
        {
            yield return www.SendWebRequest();

            //Debug.Log(www.downloadHandler.text);

            if (www.downloadHandler.text == "0: Sucess!")
            {
               // Debug.Log("Deathcoordinates sucessfully stored in database");

            }
        }
    }


    IEnumerator RetriveDeadSpawnPointsFromWeb()

    {

        UnityWebRequest www = UnityWebRequest.Get("http://hawaiipizza.dk/stuff/retrivedatafromweb.php");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
           // Debug.Log(www.error);
        }
        else
        {


            //  retrieve results as string
            string[] results = www.downloadHandler.text.Split('\t'); ;
            SpawnTrees(results);
            
        }
    }

    public void SpawnTrees(string[] recievedData)
    {
        int lengthoftable = recievedData.Length - 1;
        for (int i = 0; i < lengthoftable; i++)
        {
            string[] xyz = recievedData[i].Split('_');
            float x = float.Parse(xyz[0]);
            float y = float.Parse(xyz[1]);
            float z = float.Parse(xyz[2]);
            float playtime = float.Parse(xyz[3]);

            float logMultiplier = playtime / (worldTimer.PlayTime * 60);

            Vector3 scale = MaxSize * logMultiplier;
            Vector3 position = new Vector3(x, scale.y/2, z);
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360),0);

            GameObject graveObject = Instantiate(DeadPlayers, position, rotation, this.transform);
            graveObject.transform.localScale = scale;

           



        }
    }

}



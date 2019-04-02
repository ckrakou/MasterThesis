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

            Debug.Log(www.downloadHandler.text);

            if (www.downloadHandler.text == "0: Sucess!")
            {
                Debug.Log("logintime sucessfully stored in database");

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

            Debug.Log(www.downloadHandler.text);

            if (www.downloadHandler.text == "0: Sucess!")
            {
                Debug.Log("failed login sucessfully stored in database");

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
        DeathForm.AddField("plytime", playtime.ToString());


        //call php script
        //  WWW www = new WWW("http://hawaiipizza.dk/stuff/registerlogin.php", registerForm);


        using (UnityWebRequest www = UnityWebRequest.Post("http://hawaiipizza.dk/stuff/deadplayers.php", DeathForm))
        {
            yield return www.SendWebRequest();

            Debug.Log(www.downloadHandler.text);

            if (www.downloadHandler.text == "0: Sucess!")
            {
                Debug.Log("Deathcoordinates sucessfully stored in database");

            }
        }
    }


    IEnumerator RetriveDeadSpawnPointsFromWeb()

    {

        UnityWebRequest www = UnityWebRequest.Get("http://hawaiipizza.dk/stuff/retrivedatafromweb.php");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            //Debug.Log(www.downloadHandler.text);
            //  retrieve results as string
            string[] results = www.downloadHandler.text.Split('\t'); ;
            int lengthoftable = results.Length - 1;
            for (int i = 0; i < lengthoftable; i++)
            {
                string[] xyz = results[i].Split('_');
                float x = float.Parse(xyz[0]);
                float y = float.Parse(xyz[1]);
                float z = float.Parse(xyz[2]);
                float playtime = float.Parse(xyz[3]);
                float NewLogSize = playtime / 300;
                Vector3 vec = new Vector3(x, 0 + NewLogSize / 2, z);
                int ramdomLogY = Random.Range(-180, 180);
                Quaternion LogSpawnRotation = Quaternion.Euler(0, ramdomLogY, 0);

                GameObject newObject = Instantiate(DeadPlayers, vec, LogSpawnRotation) as GameObject;
                    Debug.Log("spawned log");
                newObject.transform.localScale = new Vector3(NewLogSize, NewLogSize, NewLogSize);



            }
        }
    }

}



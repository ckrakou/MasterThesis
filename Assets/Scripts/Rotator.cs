using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update

    public float Max = 2.5f;
    public float Min = 0.3f;
    private float speed;
   

    void Start(){
        speed = Random.Range(Min,Max);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}

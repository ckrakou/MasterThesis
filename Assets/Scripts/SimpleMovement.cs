using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{

    public float MovementSpeed = 5;
    public float TurnSpeed = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwards = Input.GetAxis("Vertical");
        float sideways = Input.GetAxis("Horizontal");

        transform.position += new Vector3(0, 0, forwards * Time.deltaTime/MovementSpeed);

    }
}

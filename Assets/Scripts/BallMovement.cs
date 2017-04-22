using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(6f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}//end BallMovement

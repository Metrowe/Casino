using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotation : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        theta = Random.Range(3,8);
        constant = 0.01f;
	}

    float theta;
    float constant;

	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, theta, 0);

        //theta -= constant;
        
        if (theta > 0)
        {
            theta -= constant;
        }
        else
        {
            theta = 0;
        }
        
    }
}

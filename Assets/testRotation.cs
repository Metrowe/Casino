using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotation : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        theta = 2f;
	}

    float theta;

	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, theta, 0);
        //theta += 0.01f;
    }
}

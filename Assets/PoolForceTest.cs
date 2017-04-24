using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolForceTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(0, 0, 6);
        }//end if
        if (Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(0, 0, -6);
        }//end if
        if (Input.GetKeyDown(KeyCode.J))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(-6, 0, 0);
        }//end if
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(6, 0, 0);
        }//end if
    }
}

//GetComponent<Rigidbody>().velocity = new Vector3(6f, 0, 0);
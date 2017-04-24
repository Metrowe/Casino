using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    void OnMouseOver()
    {
        //gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
    }



    void OnMouseEnter()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
    }
    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
    }



}

//mObjectName.gameObject.renderer.material.color = new Color(R, G, B, A);
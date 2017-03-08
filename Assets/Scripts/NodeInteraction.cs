using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInteraction : MonoBehaviour
{
    void objectStart()
    {
        //GetComponent<Renderer>().enabled = false;
    }//end objectStart

	void Update ()
    {
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().enabled = true;
    }//end OnMouseEnter

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Renderer>().enabled = false;
        }//end if
    }//end OnMouseOver

    void OnMouseExit()
    {
        //GetComponent<Renderer>().enabled = false;
        GetComponent<Renderer>().enabled = true;
    }//end OnMouseExit

    /////////////gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255);

}//end NodeInteraction

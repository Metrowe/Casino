using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RouletteGame : MonoBehaviour
{
    public Object BetNode;

    // Use this for initialization
    void Start ()
    {
        Vector3 fix = new Vector3(1, 2, 0) + this.transform.position;

        GameObject localNode = Instantiate(BetNode, new Vector3(0, 0, 0) + fix, transform.rotation) as GameObject;
        //GameObject.Instantiate(BetNode, new Vector3(0, 0, 0) + fix, transform.rotation);
    }//end Start

    // Update is called once per frame
    void Update ()
    {
		
	}//end Update
}//end RouletteGame

/*

    public class ExampleClass : MonoBehaviour
    {
	    public GameObject player;

	    //Invoked when a button is pressed.
	    public void SetParent( GameObject newParent )
	    {
		    //Makes the GameObject "newParent" the parent of the GameObject "player".
		    player.transform.parent = newParent.transform;
			
		    //Display the parent's name in the console.
		    Debug.Log( "Player's Parent: " + player.transform.parent.name );

		    // Check if the new parent has a parent GameObject.
		    if( newParent.transform.parent != null )
		    {
			    //Display the name of the grand parent of the player.
			    Debug.Log( "Player's Grand parent: " + player.transform.parent.parent.name );
		    }
	    }

	    public void DetachFromParent( )
	    {
		    // Detaches the transform from its parent.
		    transform.parent = null;
	    }
    }

    ////////////////////////////////////////////////////////////////////////////

 GameObject childObject = Instantiate(YourObject) as GameObject;
 childObject.transform.parent = parentObject.transform
 using System.Collections.Generic

    ////////////////////////////////////////////////////////////////////////////

  private GameObject sceneParent, myRocket;
 
 void Start () {
     sceneParent = GameObject.Find("SceneParent");
     myRocket = GameObject.Find("Raket");
     myRocketDeepChild = myRocket.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
     //the Deep child is one of the indermost children in the structure. 
     //It is simply a container for graphics that I want to handle.
     }

    ///////////////////////////////////////////////////////////////////////

    using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
    void Start() {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0.5F, 0);
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(0, 1.5F, 0);
        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.transform.position = new Vector3(2, 1, 0);
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = new Vector3(-2, 1, 0);
    }
}

    /////////////////////////////////////////////////////////////////////////

    function OnMouseDown ()
{
   Application.LoadLevel ("insideScene");
}

function OnMouseOver ()
{
   if (Input.GetMouseButtonDown (1) == true)
   {
      //put code here
   }
}

    //////////////////////////////////////////////////////////////////
    */

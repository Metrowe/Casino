using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RouletteGame : MonoBehaviour
{
    public GameObject BetNode;

    // Use this for initialization
    void Start ()
    {
        //Vector3 fix = new Vector3(0.0f, 2.0f, 0.0f) + this.transform.position;
        //Vector3 fix = new Vector3(-0.354f, 1.09f, -0.739f);
        Vector3 fix = new Vector3(-0.354f, 1.18f, -0.739f);
        //Vector3 grid = new Vector3(0.17f, 0.05f, 0.126f);
        Vector3 grid = new Vector3(0.17f, 0.05f, 0.126f);
        //fix.x += 0;
        //fix.y += 5;
        //fix.z += 0;

        GameObject localNode = Instantiate(BetNode) as GameObject;
        localNode.transform.parent = this.transform;
        localNode.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f) + fix;
        localNode.transform.localScale = new Vector3(grid.x, grid.y, grid.z);

        localNode = Instantiate(BetNode) as GameObject;
        localNode.transform.parent = this.transform;
        localNode.transform.localPosition = new Vector3(0.0f + grid.x*2, 0.0f, 0.0f) + fix;
        localNode.transform.localScale = new Vector3(grid.x, grid.y, grid.z);

        localNode = Instantiate(BetNode) as GameObject;
        localNode.transform.parent = this.transform;
        localNode.transform.localPosition = new Vector3(0.0f + grid.x * 1, 0.0f, 0.0f) + fix;
        localNode.transform.localScale = new Vector3(grid.x, grid.y, grid.z);
        //GameObject myNewInstance = (GameObject)Instantiate(instance, transform.position, transform.rotation);
        // myNewInstance.transform.localPosition = new Vector3(0.0f, 0.0f, 5.0f);

        if (localNode == null)
        {
            Debug.LogWarning("LocalNode somehow isnt fudging created?");
        }


        //fix = localNode.transform.position;

        // static List < GameObject > SpawnedBoxList = new List < GameObject > ();

        //cube.transform.position = new Vector3(0, 0.5F, 0);

        //localNode = Instantiate(BetNode, new Vector3(2, 2, 2) + fix, transform.rotation) as GameObject;
        //localNode = Instantiate(BetNode, new Vector3(-2, 2, -2) + fix, transform.rotation) as GameObject;

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

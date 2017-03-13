using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RouletteGame : MonoBehaviour
{
    public GameObject BetNode;
    private Vector3 fix = new Vector3(-0.354f, 1.11f, -0.739f);
    private Vector3 grid = new Vector3(0.175f, 0.001f, 0.135f);

    private List<GameObject> storedNodes;
    // Use this for initialization
    public void startSelf()
    {
        buildAllNodes();
    }//end setSelf

    public void endSelf()
    {
        Debug.Log("endSelf called");
        for (int i = storedNodes.Count - 1; i > -1; i--)
        {
            Destroy(storedNodes[i]);
            //Debug.Log("Value[" + i + "] = " + values[i]);
        }//end for
    }//end setSelf

    void Start ()
    {
        storedNodes = new List<GameObject>();
        //buildAllNodes();

        /*
        List<int> tempListA;
        List<int> tempListB;
        List<int> tempListC;

        tempListA = new List<int>();


        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                buildNode(j,0,i,    1,1,1,  tempListA);
            }//end for
        }//end for

        

        tempListA = new List<int>();

        tempListA.Add(1);

        //Here you add 3 BadGuys to the List
        tempListA.Add(1);
        //buildNode(1,0,1,    1,1,1);
        //buildNode(2,0,2,    1,1,1);
        //buildNode(0.5f,0.1f,0.5f,    0.5f,1,0.5f);

        */
        /*
        GameObject localNode = Instantiate(BetNode) as GameObject;
        localNode.transform.parent = this.transform;
        localNode.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f) + fix;
        localNode.transform.localScale = new Vector3(grid.x, grid.y, grid.z);
        */
        //GameObject myNewInstance = (GameObject)Instantiate(instance, transform.position, transform.rotation);
        // myNewInstance.transform.localPosition = new Vector3(0.0f, 0.0f, 5.0f);




        //fix = localNode.transform.position;

        // static List < GameObject > SpawnedBoxList = new List < GameObject > ();

        //cube.transform.position = new Vector3(0, 0.5F, 0);

        //localNode = Instantiate(BetNode, new Vector3(2, 2, 2) + fix, transform.rotation) as GameObject;
        //localNode = Instantiate(BetNode, new Vector3(-2, 2, -2) + fix, transform.rotation) as GameObject;

        //GameObject.Instantiate(BetNode, new Vector3(0, 0, 0) + fix, transform.rotation);
    }//end Start

    void buildAllNodes()
    {
        int limit = 36 + 1;
        List<int> tempListA = new List<int>();
        List<int> tempListB = new List<int>();
        List<int> tempListC = new List<int>();

        //Zero
        tempListA = new List<int>();
        tempListA.Add(0);

        buildNode(1,0,-1,   3,1,1,    tempListA,    35);

        //Straights
        for (int i = 1, x = 0, y = 0; i < limit; i++)
        {
            tempListA = new List<int>();
            tempListA.Add(i);

            buildNode(2 - y,0,x,   1,1,1,    tempListA,     35);
            
            y = (y + 1) % 3;

            if(y == 0)
            {
                x++;
            }//end if
        }//end for

        
        //2 to 1
        tempListA = new List<int>();
        tempListB = new List<int>();
        tempListC = new List<int>();

        for (int i = 1; i < limit; i++)
        {
            if (i % 3 == 0)
            {
                tempListA.Add(i);
            }//end if
            else if (i % 3 == 2)
            {
                tempListB.Add(i);
            }//end else if
            else
            {
                tempListC.Add(i);
            }//end else
        }//end for

        buildNode(0,0,12,   1,1,1,    tempListA,    2);
        buildNode(1,0,12,   1,1,1,    tempListB,    2);
        buildNode(2,0,12,   1,1,1,    tempListC,    2);

        
        //Dozens
        tempListA = new List<int>();
        tempListB = new List<int>();
        tempListC = new List<int>();

        for (int i = 1; i < limit; i++)
        {
            if(  i < 13  )
            {
                tempListA.Add(i);
            }//end if
            else if(  i > 12 && i < 25)
            {
                tempListB.Add(i);
            }//end else if
            else
            {
                tempListC.Add(i);
            }//end else
        }//end for
    
        buildNode(3,0,1.5f,   1,1,4,    tempListA,    2);
        buildNode(3,0,5.5f,   1,1,4,    tempListB,    2);
        buildNode(3,0,9.5f,   1,1,4,    tempListC,    2);

        
        //Lows-highs
        tempListA = new List<int>();
        tempListB = new List<int>();

        for (int i = 1; i < limit; i++)
        {
            if(  i < 19  )
            {
                tempListA.Add(i);
            }//end if
            else 
            {
                tempListB.Add(i);
            }//end else 
        }//end for

        buildNode(4,0,0.5f,    1,1,2,    tempListA,    1);
        buildNode(4,0,10.5f,   1,1,2,    tempListB,    1);

        
        //Evens-odds
        tempListA = new List<int>();
        tempListB = new List<int>();

        for (int i = 1; i < limit; i++)
        {
            if(  i % 2 == 0  )
            {
                tempListA.Add(i);
            }//end if
            else 
            {
                tempListB.Add(i);
            }//end else 
        }//end for
    
        buildNode(4,0,2.5f,    1,1,2,    tempListA,    1);
        buildNode(4,0,8.5f,    1,1,2,    tempListB,    1);
    }//end buildAllNodes

    void buildNode(float px, float py, float pz,    float sx, float sy, float sz,   List<int> tempList,     int pay)
    {
        GameObject localNode = Instantiate(BetNode) as GameObject;
        localNode.transform.parent = this.transform;
        localNode.transform.localPosition = new Vector3(px * grid.x, py * grid.y, pz * grid.z) + fix;
        localNode.transform.localScale = new Vector3(sx * grid.x, sy * grid.y, sz * grid.z);

        localNode.GetComponent<NodeInteraction>().values = tempList;
        localNode.GetComponent<NodeInteraction>().payout = pay;
        storedNodes.Add(localNode);

        if (localNode == null)
        {
            Debug.LogWarning("LocalNode somehow isnt fudging created?");
        }
    }//end buildNode

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

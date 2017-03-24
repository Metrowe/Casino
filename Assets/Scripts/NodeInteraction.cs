using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInteraction : MonoBehaviour
{
    public List<int> values;
    public int payout;
    public int stackValue;
    public GameObject chipStack;
    //private GameObject chipStack = new GameObject();

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
            GameObject temp = GameObject.Find("Roulette");
            int total = payout * temp.GetComponent<RouletteGame>().currentBet + temp.GetComponent<RouletteGame>().currentBet;
            temp.GetComponent<RouletteGame>().makeBet(values, total );

            stackValue += temp.GetComponent<RouletteGame>().currentBet;

            buildChipStack();
            //GetComponent<Renderer>().enabled = false;

            for (int i = 0; i < values.Count; i++)
            {
                Debug.Log("Value[" + i + "] = " + values[i]);
            }//end for
        }//end if
    }//end OnMouseOver

    void OnMouseExit()
    {
        GetComponent<Renderer>().enabled = false;
    }//end OnMouseExit

    void buildChipStack()
    {
        //GameObject temp = GameObject.Find("Roulette");
        //chipTypes = temp.GetComponent<RouletteGame>().chipTypes;
        //GameObject[] chipTypes = temp.GetComponent<RouletteGame>().chipTypes;
        Destroy(chipStack);

        Debug.Log("entered buildChipStack");
        
        chipStack = new GameObject();
        chipStack.transform.parent = this.transform;

        chipStack.transform.localPosition = new Vector3(0, 0, 0);
        chipStack.transform.localRotation = new Quaternion();
        
        Debug.Log("created chipStack");
        
        float dist = 0.01f;
        int stackIndex = 0;
        int tempValue = stackValue;

        Debug.Log("about to enter first while");
        while (tempValue >= 1000)
        {
            Debug.Log("stackIndex = " + stackIndex);
            buildChip(stackIndex * dist, 6);
            stackIndex++;
            tempValue -= 1000;
        }//end while

        //Debug.Log(tempValue);
        
        while (tempValue >= 500)
        {
            buildChip(stackIndex * dist, 5);
            stackIndex++;
            tempValue -= 500;
        }//end while

        while (tempValue >= 100)
        {
            buildChip(stackIndex * dist, 4);
            stackIndex++;
            tempValue -= 100;
        }//end while

        while (tempValue >= 50)
        {
            buildChip(stackIndex * dist, 3);
            stackIndex++;
            tempValue -= 50;
        }//end while

        while (tempValue >= 10)
        {
            buildChip(stackIndex * dist, 2);
            stackIndex++;
            tempValue -= 10;
        }//end while
        
        while (tempValue >= 5)
        {
            buildChip(stackIndex * dist, 1);
            stackIndex++;
            tempValue -= 5;
        }//end while
        
        while (tempValue >= 1)
        {
            buildChip(stackIndex * dist, 0);
            stackIndex++;
            tempValue -= 1;
        }//end while

    }//end buildChipStack

    void buildChip(float height, int prefabIndex)
    {
        //GameObject temp = GameObject.Find("Roulette");
        //GameObject[] chipTypes = temp.GetComponent<RouletteGame>().chipTypes;

        //GameObject localChip = Instantiate(chipTypes[prefabIndex]) as GameObject;

        GameObject localChip = Instantiate(     GameObject.Find("Roulette").GetComponent<RouletteGame>().chipTypes[prefabIndex]) as GameObject;

        localChip.transform.parent = chipStack.transform;
        localChip.transform.localPosition = new Vector3(0, height, 0);
        //localNode.transform.localScale = new Vector3(sx * grid.x, sy * grid.y, sz * grid.z);
        localChip.transform.localRotation = new Quaternion();
        localChip.GetComponent<Collider>().enabled = false;

        //localNode.GetComponent<NodeInteraction>().values = tempList;
        //localNode.GetComponent<NodeInteraction>().payout = pay;
        //storedNodes.Add(localNode);

        /*
        if (localNode == null)
        {
            Debug.LogWarning("LocalNode somehow isnt fudging created?");
        }//end if
        */
    }//end buildNode
     /*
      public Texture texture; // assign in inspector, this is a field.

      GameObject go = Instantiate(somePrefab, someTransform, someRotation);
      go.renderer.material.mainTexture = texture;
      */

    /*
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
    */

    /////////////gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255);

}//end NodeInteraction

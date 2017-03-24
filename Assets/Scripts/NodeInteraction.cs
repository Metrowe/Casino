using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInteraction : MonoBehaviour
{
    public List<int> values;
    public int payout;
    private int stackValue;
    private GameObject chipStack;
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
        chipStack = new GameObject();

    }//end buildChipStack

    void buildChip(float height, int prefabIndex)
    {
        GameObject temp = GameObject.Find("Roulette");
        GameObject[] chipTypes = temp.GetComponent<RouletteGame>().chipTypes;

        GameObject localNode = Instantiate(chipTypes[prefabIndex]) as GameObject;
        localNode.transform.parent = chipStack.transform;
        localNode.transform.localPosition = new Vector3(0, height, 0);
        //localNode.transform.localScale = new Vector3(sx * grid.x, sy * grid.y, sz * grid.z);
        localNode.transform.localRotation = new Quaternion();

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

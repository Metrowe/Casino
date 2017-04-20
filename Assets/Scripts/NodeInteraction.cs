using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInteraction : MonoBehaviour
{
    public GameObject BaseChip;

    public List<int> values;
    public int payout;

    public int stackValue;
    public GameObject chipStack;

    //private GameObject chipStack = new GameObject();

    public void objectStart()
    {
        GetComponent<Renderer>().enabled = false;
        stackValue = 0;
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
        GameObject tempGame = GameObject.Find("Roulette");

        if (Input.GetMouseButtonDown(0) && !tempGame.GetComponent<RouletteGame>().spinning)
        {
            //GameObject tempGame = GameObject.Find("Roulette");
            GameObject tempPlayer = GameObject.Find("Player");
            int currentBet = tempGame.GetComponent<RouletteGame>().betAmount[tempGame.GetComponent<RouletteGame>().betIndex];

            if (tempPlayer.GetComponent<CharacterControl>().wallet >= currentBet)
            {
                tempPlayer.GetComponent<CharacterControl>().wallet -= currentBet;

                int total = (payout * currentBet) + currentBet;
                tempGame.GetComponent<RouletteGame>().makeBet(values, total);

                stackValue += currentBet;

                buildChipStack();

                for (int i = 0; i < values.Count; i++)
                {
                    Debug.Log("Value[" + i + "] = " + values[i]);
                }//end for
            }//end if
            else
            {
                Debug.Log("No dolla dolla bills yo");
            }//end else
        }//end if
    }//end OnMouseOver

    void OnMouseExit()
    {
        GetComponent<Renderer>().enabled = false;
    }//end OnMouseExit

    void buildChipStack()
    {
        Destroy(chipStack);

        Debug.Log("entered buildChipStack");
        
        chipStack = new GameObject();
        chipStack.name = "chipStack";
        chipStack.transform.parent = this.transform;

        chipStack.transform.localPosition = new Vector3(0, 0, 0);
        chipStack.transform.localRotation = new Quaternion();
        
        Debug.Log("created chipStack");
        
        float dist = 0.01f;
        //int tempValue = stackValue;

        List<int> chipdexes = BaseChip.GetComponent<ChipDynamics>().minList(stackValue);

        for(int i = 0; i < chipdexes.Count; i++)
        {
            buildChip(dist * (i + 0.5f), chipdexes[i]);
        }//end for
    }//end buildChipStack

    void buildChip(float height, int typeIndex)
    {
        GameObject localChip = Instantiate(BaseChip) as GameObject;

        localChip.transform.parent = chipStack.transform;
        localChip.GetComponent<ChipDynamics>().staticChip(typeIndex, new Vector3(0, height, 0), new Quaternion());

        //localChip.transform.localPosition = new Vector3(0, height, 0);
        //localChip.transform.localRotation = new Quaternion();
    }//end buildChip
}//end NodeInteraction

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

/*
    Debug.Log("about to enter first while");
    while (tempValue >= 1000)
    {
        Debug.Log("stackIndex = " + stackIndex);
        buildChip(  stackIndex * dist, 6);
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
    */

/////////////gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255);


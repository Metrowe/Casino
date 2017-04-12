using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipDynamics : MonoBehaviour
{
    public Material[] chipTypes = new Material[7];

    void Start ()
    {
		
	}//end Start

	void Update ()
    {
		
	}//end update

    public void staticChip(int index, Vector3 pos, Quaternion theta)
    {
        assignValue(index);

        this.transform.localPosition = pos;
        this.transform.localRotation = theta;
        //transform.Translate(pos);
        //transform.Rotate(theta);

        GetComponent<Collider>().enabled = false;
    }//end staticChip

    public void physicsChip(int index)
    {
        assignValue(index);
    }//end physicsChip

    public List<int> minList(int total)
    {
        List<int> chipIndexes = new List<int>();

        while (total >= 1000)
        {
            chipIndexes.Add(6);
            total -= 1000;
        }//end while

        while (total >= 500)
        {
            chipIndexes.Add(5);
            total -= 500;
        }//end while

        while (total >= 100)
        {
            chipIndexes.Add(4);
            total -= 100;
        }//end while

        while (total >= 50)
        {
            chipIndexes.Add(3);
            total -= 50;
        }//end while

        while (total >= 10)
        {
            chipIndexes.Add(2);
            total -= 10;
        }//end while

        while (total >= 5)
        {
            chipIndexes.Add(1);
            total -= 5;
        }//end while

        while (total >= 1)
        {
            chipIndexes.Add(0);
            total -= 1;
        }//end while

        return chipIndexes;
    }//end minList







    /*
    void buildChipStack()
    {
        //GameObject temp = GameObject.Find("Roulette");
        //chipTypes = temp.GetComponent<RouletteGame>().chipTypes;
        //GameObject[] chipTypes = temp.GetComponent<RouletteGame>().chipTypes;
        Destroy(chipStack);

        Debug.Log("entered buildChipStack");

        chipStack = new GameObject();
        chipStack.name = "chipStack";
        chipStack.transform.parent = this.transform;

        chipStack.transform.localPosition = new Vector3(0, 0, 0);
        chipStack.transform.localRotation = new Quaternion();

        Debug.Log("created chipStack");

        float dist = 0.01f;
        float stackIndex = 0.5f;
        int tempValue = stackValue;
    }//end buildChipStack
    */























    public void assignValue(int index)
    {
        GetComponent<Renderer>().material = chipTypes[index];
    }//end assignValue
}

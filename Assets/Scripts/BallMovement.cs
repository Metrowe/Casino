using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(6f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startRoll()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(rdm(2), 1, rdm(2));
        //transform.localPosition = new Vector3(rdm(2), 1, rdm(2)) + GameObject.Find("Wheel V4").GetComponent<WheelMovement>().transform.position;
        transform.position = new Vector3(rdm(0.3f), 0.2f, rdm(0.3f)) + GameObject.Find("Wheel V4").GetComponent<WheelMovement>().transform.position;
    }//end startRoll

    /*
    private float rdm(float num1,float num2)
    {
        return Random.Range(num1, num2);
    }
    */

    private float rdm(float num)
    {
        return Random.Range(-num, num);
    }//end rdm
}//end BallMovement

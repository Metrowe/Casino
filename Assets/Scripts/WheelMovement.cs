using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovement : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        spinSpeed = resetSpeed;
        count = resetCount;
    }//end Start

    private int count;
    private float spinSpeed;

    private int resetCount = 300;
    private float resetSpeed = 3.0f;

    

    public void updateSelf()
    {
        transform.Rotate(0, spinSpeed, 0);

        if (count > 1)
        {
            if(count < resetCount * 0.5f)
            {
                spinSpeed -= resetSpeed / (resetCount * 0.5f);
            }
            print("Wheel y theta = " + gameObject.transform.rotation.y);

            count--;
        }//end if
        else
        {
            
            GameObject tempGame = GameObject.Find("Roulette");
            int result = tempGame.GetComponent<RouletteGame>().calculateWindex(); ;
            tempGame.GetComponent<RouletteGame>().winBet(result);

            spinSpeed = resetSpeed;
            count = resetCount;

            //spinspeed = //Random.Range(0.1f, 0.2f);
            //print("Wheel x theta = " + gameObject.transform.rotation.x);
            //print("Wheel y theta = " + gameObject.transform.rotation.y);
            //print("Wheel z theta = " + gameObject.transform.rotation.z);

        }//end else
    }//end updateSelf
}//end WheelMovement
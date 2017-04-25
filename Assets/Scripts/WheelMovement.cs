using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovement : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //theta = Random.Range(3, 8);
        theta = 0;
        //constant = 0.01f;

        spinspeed = 3;//Random.Range(0.5f, 3.0f);
    }

    public float theta;
    //private float constant;
    private int count = 3;

    float spinspeed = 20;

    public void updateSelf()
    {
        //transform.Rotate(0, spinspeed, 0);
        transform.Rotate(0, spinspeed, 0);

        if (count > 0)
        {
            print("Wheel y theta = " + gameObject.transform.rotation.y);

            count--;
        }//end if
        else
        {
            //theta = 0;

            GameObject.Find("Roulette").GetComponent<RouletteGame>().winBet(0);

            count = 3;

            //spinspeed = //Random.Range(0.1f, 0.2f);
            //print("Wheel x theta = " + gameObject.transform.rotation.x);
            //print("Wheel y theta = " + gameObject.transform.rotation.y);
            //print("Wheel z theta = " + gameObject.transform.rotation.z);

        }//end else
    }//end updateSelf
            /*

            GameObject tempGame = GameObject.Find("Roulette");

            tempGame.GetComponent<RouletteGame>().winBet(0);
            tempGame.GetComponent<RouletteGame>().spinning = false;
            
        }
        //end else





        /*
        transform.Rotate(0, theta, 0);
        
        //theta -= constant;

        if (theta > 0)
        {
            theta -= constant;
            print("Wheel y theta = " + gameObject.transform.rotation.y);
        }//end if
        else
        {
            theta = 0;

            GameObject.Find("Roulette").GetComponent<RouletteGame>().winBet(0);

            //print("Wheel x theta = " + gameObject.transform.rotation.x);
            print("Wheel y theta = " + gameObject.transform.rotation.y);
            //print("Wheel z theta = " + gameObject.transform.rotation.z);
            /*
            GameObject tempGame = GameObject.Find("Roulette");

            tempGame.GetComponent<RouletteGame>().winBet(0);
            tempGame.GetComponent<RouletteGame>().spinning = false;
            
        }//end else
        
        }//end updateSelf
        */

        
    }//end WheelMovement

        /*
        gameObject.transform.rotation.x; gameObject.transform.rotation.y; gameObject.transform.rotation.z;
        These will return world coordinates.
        gameObject.transform.localrotation.x; gameObject.transform.localrotation.y; gameObject.transform.localrotation.z;
        */

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
        constant = 0.01f;
    }

    public float theta;
    private float constant;

    // Update is called once per frame
    /*
    void Update()
    {
        transform.Rotate(0, theta, 0);

        //theta -= constant;

        if (theta > 0)
        {
            theta -= constant;
        }
        else
        {
            theta = 0;
        }

    }
    */
    public void updateSelf()
    {
        transform.Rotate(0, theta, 0);

        //theta -= constant;

        if (theta > 0)
        {
            theta -= constant;
        }//end if
        else
        {
            theta = 0;

            GameObject.Find("Roulette").GetComponent<RouletteGame>().winBet(0); 

            /*
            GameObject tempGame = GameObject.Find("Roulette");

            tempGame.GetComponent<RouletteGame>().winBet(0);
            tempGame.GetComponent<RouletteGame>().spinning = false;
            */
        }//end else
    }//end updateSelf
}//end WheelMovement

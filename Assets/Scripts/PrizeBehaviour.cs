﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeBehaviour : MonoBehaviour
{
    public GameObject Prize;
    //GameObject Player;

    public int cost;

	// Use this for initialization
	void Start ()
    {
        cost = 20;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    

    void OnMouseEnter()
    {
        GameObject.Find("Player").GetComponent<CharacterControl>().showPrice(true, cost);
    }//end OnMouseEnter

    void OnMouseOver()
    {
        //GameObject tempPlayer = GameObject.Find("Player");

        //if (Input.GetMouseButtonDown(0) && !tempGame.GetComponent<RouletteGame>().spinning)
        if (Input.GetMouseButtonDown(0))
        {
            GameObject tempPlayer = GameObject.Find("Player");
            GameObject localPrize = Instantiate(Prize) as GameObject;

            localPrize.GetComponent<PositionPrize>().heldPrize(tempPlayer, new Vector3(
                //Random.Range(-0.2f,0.2f), 
                1,
                //1, 
                tempPlayer.GetComponent<CharacterControl>().heldPrizes.Count * 1,
                2), 
                new Quaternion());
        }//end if
    }//end OnMouseOver

    void OnMouseExit()
    {
        GameObject.Find("Player").GetComponent<CharacterControl>().showPrice(false, cost);
    }//end OnMouseEnter
}//end PrizeBehaviour

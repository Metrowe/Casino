using System.Collections;
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
        GameObject tempPlayer = GameObject.Find("Player");

        //if (Input.GetMouseButtonDown(0) && !tempGame.GetComponent<RouletteGame>().spinning)
        if (Input.GetMouseButtonDown(0) && tempPlayer.GetComponent<CharacterControl>().wallet >= cost)
        {
            //GameObject tempPlayer = GameObject.Find("Player");
            tempPlayer.GetComponent<CharacterControl>().wallet -= cost;

            GameObject localPrize = Instantiate(Prize) as GameObject;

            localPrize.GetComponent<PositionPrize>().heldPrize(tempPlayer, new Vector3(
                //Random.Range(-0.2f,0.2f), 
                1,
                //1, 
                tempPlayer.GetComponent<CharacterControl>().heldPrizes.Count * 1,
                2), 
                new Quaternion());

            if(cost <= 0)
            {
                Destroy(this.gameObject);
            }
        }//end if
    }//end OnMouseOver

    public void setCost()
    {
        cost = 0;
    }

    void OnMouseExit()
    {
        GameObject.Find("Player").GetComponent<CharacterControl>().showPrice(false, cost);
    }//end OnMouseEnter
}//end PrizeBehaviour

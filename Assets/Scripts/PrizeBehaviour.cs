using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeBehaviour : MonoBehaviour
{
    public GameObject Prize;
    //GameObject Player;

    public int cost;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void heldPrize(GameObject myParent, Vector3 pos, Quaternion theta)
    {
        this.transform.parent = myParent.transform;
        this.transform.localPosition = pos;
        this.transform.localRotation = theta;

        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }//end staticChip

    void OnMouseOver()
    {
        //GameObject tempPlayer = GameObject.Find("Player");

        //if (Input.GetMouseButtonDown(0) && !tempGame.GetComponent<RouletteGame>().spinning)
        if (Input.GetMouseButtonDown(0))
        {
            GameObject localChip = Instantiate(Prize) as GameObject;

            heldPrize(GameObject.Find("Player"), new Vector3(     Random.Range(-0.2f,0.2f)              , 1, 2), new Quaternion());
        }//end if
    }//end OnMouseOver


}

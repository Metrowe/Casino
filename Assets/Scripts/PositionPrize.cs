using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPrize : MonoBehaviour
{
    public GameObject Prize;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void heldPrize(GameObject myParent, Vector3 pos, Quaternion theta)
    {
        //this.transform.parent = myParent.transform;
        this.transform.parent = GameObject.Find("Player").transform;
        this.transform.localPosition = pos;
        this.transform.localRotation = theta;
        myParent.GetComponent<CharacterControl>().heldPrizes.Add(this.gameObject);
        //GetComponent<Collider>().enabled = false;
        //GetComponent<Rigidbody>().isKinematic = true;
    }//end staticChip

    public void dropPrize()
    {

    }
}

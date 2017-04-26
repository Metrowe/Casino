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
        myParent.GetComponent<CharacterControl>().carryCheck();
        //GetComponent<Collider>().enabled = false;
        //GetComponent<Rigidbody>().isKinematic = true;
    }//end staticChip

    public void dropPrize()
    {
        //GameObject tempPlayer = GameObject.Find("Player");
        GameObject localPrize = Instantiate(Prize) as GameObject;

        //localPrize.tranform.Position = transform.position;
        localPrize.GetComponent<PrizeBehaviour>().setCost();
        localPrize.transform.localPosition = transform.position;
        localPrize.transform.localRotation = transform.rotation;
        localPrize.AddComponent<Rigidbody>();
        //localPrize.GetComponent<PrizeBehaviour>().cost = 0;

       Destroy(this.gameObject);
    }
}

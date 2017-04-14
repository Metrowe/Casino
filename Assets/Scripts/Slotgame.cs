using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slotgame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}

    public float smooth = 2.0f;
    public float tilt = 30.0f;

    public void startSelf()
	{
        float spinArmZ = -Input.GetAxis("Fire1") * tilt;
        GameObject cur = GameObject.Find("Arm");
        Quaternion target = Quaternion.Euler(0, 0, spinArmZ*3 );
        cur.transform.rotation = Quaternion.Slerp(cur.transform.rotation, target, Time.deltaTime * smooth);

        //print(cur.transform.eulerAngles.z);

       if(cur.transform.eulerAngles.z < 280 && cur.transform.eulerAngles.z > 0)
       {
            wheelspin();
       }
    }

    public void wheelspin()
    {
        print("Works");
    }


	void Update () {

 
      
       
		}
	
}
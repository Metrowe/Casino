using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slotgame : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    public void startSelf()
    {
    }

    bool slot = false;
    bool spin = false;

    public void updateSelf()
    {

        float smooth = 2.0f;
        float tilt = 30.0f;
       float spinArmZ = 0;
    
        if (spin == false)
        {
           spinArmZ = -Input.GetAxis("Fire1") * tilt;
        }

        GameObject cur = GameObject.Find("Arm");
        Quaternion target = Quaternion.Euler(0, 0, spinArmZ * 3);
        cur.transform.rotation = Quaternion.Slerp(cur.transform.rotation, target, Time.deltaTime * smooth);

        if (cur.transform.eulerAngles.z < 280 && cur.transform.eulerAngles.z > 0)
        {
            spin = true;
            wheelspin();
        }
    }

    void wheelspin()
    {
         print("Work");
    }


	//void Update () {

 
      
       
		
	
}
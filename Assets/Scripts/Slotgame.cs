using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slotgame : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    public void startSelf()
    {
        //result = new int [3];

    }

    bool slot = false;
    bool spin = false;
    int losses = 0;
    
    public int [] result;
    
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
        result = new int[3];

        GameObject wheel1 = GameObject.Find("Rotatey thing 1");
        GameObject wheel2 = GameObject.Find("Rotatey thing 2");
        GameObject wheel3 = GameObject.Find("Rotatey thing 3");


        for (int i = 0 ; i < 3 ; i++ )
        {
            result[i] = Random.Range(0, 3);
        }

        for (int i = 0; i < 3; i++)
        {
            print(result[i]);
        }

        if (result[0] == result[1] && result[1] == result[2])
        {
            print("Jackpot");
            losses = 0;
            print(losses);
            
        }

        if (result[0] != result[1])
        {
            print("No prize :(");
            losses++;
            print(losses);
        }

        spin = false;


    }
 
      
       
		
	
}
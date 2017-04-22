using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slotgame : MonoBehaviour {

    // Use this for initialization
    void Start() {
        originalrotation = transform.rotation;
    }

    public void startSelf()
    {
        //result = new int [3];

    }

    bool slot = false;
    bool spin = false;
    int losses = 0;

    public Quaternion originalrotation;
    public Quaternion jackpot;
    public Quaternion pupper;
    public Quaternion sevens;
    public Quaternion grape;

    public float resetspeed = 1.0f ;
    
    public int [] result;

    public void updateSelf()
    {
        float spinArmZ = 0;
        float smooth = 2.0f;
        float tilt = 30.0f;
    
        if (spin == false)
        {
           spinArmZ = -Input.GetAxis("Fire1") * tilt;
        }

        GameObject cur = GameObject.Find("Arm");
        Quaternion target = Quaternion.Euler(0, 0, spinArmZ * 3);
        cur.transform.rotation = Quaternion.Slerp(cur.transform.rotation, target, Time.deltaTime * smooth);

        if (spin == false && cur.transform.eulerAngles.z < 280 && cur.transform.eulerAngles.z > 0)
        {
            spin = true;
            Invoke("wheelspin", 1);
        }
    }

    public void wheelspin()
    {

        ///////////
        print("Entering wheel spin");
        ///////////

        result = new int[3];

        GameObject wheel1 = GameObject.Find("Rotatey thing 1");
        GameObject wheel2 = GameObject.Find("Rotatey thing 2");
        GameObject wheel3 = GameObject.Find("Rotatey thing 3");

        if (losses < 5)
        {
            for (int i = 0; i < 3; i++)
            {
                result[i] = Random.Range(0, 3);

            }

        }

        if (losses > 5)
        {
            for (int i = 0; i < 3; i++)
            {
                result[3] = 0;
            }
        }

        if (result[0] == 0)
        {
            for (int i = 0; i < 50 + 360; i++)
            {
                wheel1.transform.Rotate(0, 1, 0);
          
            }
        }

        if (result[1] == 0)
        {
            for (int i = 0; i < 50 + 360; i++)
            {
                wheel2.transform.Rotate(0, 1, 0);

            }
        }

        if (result[2] == 0)
        {
            for (int i = 0; i < 50 + 360; i++)
            {
                wheel3.transform.Rotate(0, 1, 0);

            }
        }

        


        /*if (result[0] == 0)
        {
            Quaternion spin = Quaternion.Euler(25, 0, 0);
            wheel1.transform.rotation = Quaternion.Slerp(wheel1.transform.rotation, spin, Time.deltaTime * 30.0f);
        }
        if (result[1] == 0)
        {
            Quaternion spin = Quaternion.Euler(25, 0, 0);
            wheel2.transform.rotation = Quaternion.Slerp(wheel2.transform.rotation, spin, Time.deltaTime * 30.0f);
        }*/

        print("Results are  ");

        for (int i = 0; i < 3; i++)
        {
            print(result[i]);
        }

        if (result[0] == result[1] && result[1] == result[2])
        {
            print("Jackpot");
            losses = 0;
            print(losses);
            spin = false;
        }

        if (result[0] != result[1] || result[0] != result[2] || result[1] != result[2])
        {
            print("No prize :(");
            losses++;
            print("Losses are");
            print(losses);
            spin = false;
        }

        StartCoroutine(Wait(3.0f));


        wheel1.transform.localRotation = Quaternion.Slerp(wheel1.transform.rotation, originalrotation, Time.time * resetspeed);
        //wheel1.transform.rotation = Quaternion.Slerp(wheel1.transform.rotation, originalrotation, Time.time * resetspeed);
        wheel2.transform.rotation = Quaternion.Slerp(wheel2.transform.rotation, originalrotation, Time.time * resetspeed);
        wheel3.transform.rotation = Quaternion.Slerp(wheel3.transform.rotation, originalrotation, Time.time * resetspeed);

        ///////////
        print("Leaving wheel spin");
        ///////////

    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(2);
    }

}
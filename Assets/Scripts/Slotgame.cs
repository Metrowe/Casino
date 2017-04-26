//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slotgame : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void startSelf()
    {
        spinSpeed = 5f;
        spin = false;
        result = new int[] { 0, 0, 0 };
        Wheels = new GameObject[3];
        Wheels[0] = GameObject.Find("Rotatey thing 1");
        Wheels[1] = GameObject.Find("Rotatey thing 2");
        Wheels[2] = GameObject.Find("Rotatey thing 3");

        thetas = new float[] { 0.0f, 0.0f, 0.0f };
        spinsLeft = new float[] { 0, 0, 0 };
        pos = new int[] { 25, 70, 115, 160 };
        losses = 0;

        for (int i = 0; i < Wheels.Length; i++)
        {
            //Wheels[i].transform.localRotation = new Quaternion(0, 0, 0);
            Wheels[i].transform.rotation = Quaternion.Euler(270, 0, 0);
        }

        setText();
    }

    bool spin;
    int losses;
    float spinSpeed;

    GameObject[] Wheels;
    public GameObject BaseChip;
    float[] thetas;
    float[] spinsLeft;
    public int[] result;
    public int[] pos;
    public Text WalletText;
    //public float resetspeed = 1.0f;

    public void updateSelf()
    {
        float spinArmZ = 0;
        float smooth = 2.0f;
        float tilt = 30.0f;
        GameObject tempPlayer = GameObject.Find("Player");

        if (spin == false && tempPlayer.GetComponent<CharacterControl>().wallet > 5)
        {
            spinArmZ = -Input.GetAxis("Fire1") * tilt;
        }
        else
        {
            wheelspin();
        }

        GameObject cur = GameObject.Find("Arm");
        Quaternion target = Quaternion.Euler(0, 180, spinArmZ * 3);
        cur.transform.rotation = Quaternion.Slerp(cur.transform.rotation, target, Time.deltaTime * smooth);

        if (spin == false && cur.transform.eulerAngles.z < 280 && cur.transform.eulerAngles.z > 0)
        {
            spin = true;
            setSpin();

            tempPlayer.GetComponent<CharacterControl>().wallet -= 5;
            setText();
        }
    }

    public void setSpin()
    {
        print("Entering set spin");

        //If losses are under 5 it's random
        if (losses < 5)
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Random.Range(0, 3);
            }

        }

        //If they lose 5 times they get jackpot out of pity
        else
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = 0;
            }
        }

        for (int i = 0; i < Wheels.Length; i++)
        {
            int j;
            j = result[i];

            if (thetas[i] == pos[j])
            {
                spinsLeft[i] = Random.Range(1, 4) * 360 / spinSpeed;
            }

            if (thetas[i] < pos[j])
            {
                spinsLeft[i] = (pos[j] - thetas[i]) / spinSpeed + Random.Range(1, 4) * 360 / spinSpeed;
            }
            else
            {
                spinsLeft[i] = (pos[j] + 360 - thetas[i]) / spinSpeed + Random.Range(1, 4) * 360 / spinSpeed;
            }

            print("Spins" + spinsLeft[i]);
        }

    }

    public void wheelspin()
    {

        for (int i = 0; i < Wheels.Length; i++)
        {
            if (spinsLeft[i] > 0)
            {
                Wheels[i].transform.Rotate(0, spinSpeed, 0);
                thetas[i] = (thetas[i] += spinSpeed) % 360;
                spinsLeft[i]--;
            }
        }//end for

        if (spinsLeft[0] == 0 && spinsLeft[1] == 0 && spinsLeft[2] == 0)
        {
            spin = false;
            revealResult();
        }
    }

    public void revealResult()
    {

        if (result[0] == result[1] && result[0] == result[2])
        {
            print("Jackpot! Congratulations!");
            GameObject.Find("Player").GetComponent<CharacterControl>().wallet += 40;
            List<int> chipdexes = BaseChip.GetComponent<ChipDynamics>().minList(40);

            for (int i = 0; i < chipdexes.Count; i++)
            {
                GameObject localChip = Instantiate(BaseChip) as GameObject;

                localChip.GetComponent<ChipDynamics>().physicsChip(chipdexes[i], transform.position + new Vector3(0.2f, 1.5f, 0), new Quaternion());
            }//end for

            losses = 0;
        }

        else
        {
            print("No win :(");//😞
            losses++;
        }
        setText();
    }

    void setText()
    {
        WalletText.text = "Wallet = " + GameObject.Find("Player").GetComponent<CharacterControl>().wallet;
    }
}
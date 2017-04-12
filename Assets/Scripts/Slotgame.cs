using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slotgame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void startSelf()
	{
		//float speed = 7.0f;
		//GameObject curr ;

		/*if (Input.GetKeyDown (KeyCode.S)) 
		{
			transform.Rotate (Vector3.up, Time.deltaTime, Space.Self);
			curr = GameObject.Find("Arm");
			curr.transform.Rotate (Vector3.back, Time.deltaTime, Space.Self); 
		}*/

	}

	public float smooth = 2.0f;
	public float tilt = 30.0f;
	//public float spinArmZ = 360 * tilt;

	// Update is called once per frame
	void Update () {
		
		//GameObject cur;
		//cur = GameObject.Find ("Arm");
		float spinArmZ = Input.GetAxis ("Vertical") * tilt;
		//if (Input.GetKeyDown (KeyCode.F)) {
			
			GameObject cur;
			cur = GameObject.Find ("Arm");
			Quaternion target = Quaternion.Euler (0, 0, spinArmZ);
			transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * smooth);
		//}

		/*if (Input.GetKeyDown (KeyCode.S))
		{
			GameObject cur;

			//transform.Rotate(Vector3.back, 7.0f, Space.Self);
			cur = GameObject.Find ("Arm");


			for (int i = 0; i < 1000; i++) 
			{
				//float translation = Time.deltaTime * 3
				cur.transform.Rotate (Vector3.back * Time.deltaTime); 
				//yield return new WaitForSeconds (5);
			}
		 }*/
	}
}

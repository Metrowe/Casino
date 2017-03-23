using System.Collections;
using System.Collections.Generic;
using UnityEngine;     

public class MouseLook : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public float display1;
    public float display2;

    GameObject character;

    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    void LateUpdate()
    {
        if (!transform.parent.GetComponent<CharacterController>().inGame)
        {
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            if (md.y > 0 && transform.eulerAngles.x < 315 && transform.eulerAngles.x > 270 || md.y < 0 && transform.eulerAngles.x < 90 && transform.eulerAngles.x > 45)
            {
                md.y = 0;
            }

            display1 = transform.eulerAngles.x;
            display2 = Input.GetAxisRaw("Mouse Y");

            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            mouseLook += smoothV;

            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
        }//end if
    }//end LateUpdate
}
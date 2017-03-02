using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public float speed;
    private bool inGame;
    private bool readyGame;

    public Camera[] cameras;
    public int currentCameraIndex;
    private int tempCameraIndex;
    public Text StartGameText;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        speed = 7.0f;
        inGame = false;
        readyGame = false;

        setText(false);

        currentCameraIndex = 0;

        //Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        //If any cameras were added to the controller, enable the first one
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            //Debug.Log("Camera with name: " + cameras[0].camera.name + ", is now enabled");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {
            switch (currentCameraIndex)
            {
                case 1:
                {

                        break;
                }//end case 1
                case 2:
                {

                    break;
                }//end case 2
                case 3:
                {

                    break;
                }//end case 3
                default:
                {

                        break;
                }

            }//end switch
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentCameraIndex = 0;
                setCamera();
                inGame = false;
            }//end if
        }//end if
        else
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float straffe = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;

            transform.Translate(straffe, 0, translation);

            if (readyGame && Input.GetKeyDown(KeyCode.E))
            {
                currentCameraIndex = tempCameraIndex;
                setCamera();
                inGame = true;

                setText(false);
            }//end if
        }//end else

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }//end if
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameStartPoint"))
        {
            //currentCameraIndex = other.parent.gameObject.gameIndex;
            tempCameraIndex = other.transform.parent.GetComponent<GameStartVars>().gameIndex;

            //this.transform.parent.GetComponent<YourparentScript>().yourVariable = newValue;
            setText(true);
            readyGame = true;
        }//end if
    }//end OnTriggerEnter


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GameStartPoint"))
        {
            setText(false);
            readyGame = false;
        }//end if
    }//end OnTriggerExit


    void setCamera()
    {
        for(int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }//end for

        cameras[currentCameraIndex].gameObject.SetActive(true);
    }//end set camera

    void setText(bool show)//rename show
    {
        if(show)
        {
            StartGameText.text = "Press 'e' to play game";
        }//end if
        else
        {
            StartGameText.text = " ";
        }//edn else
    }//edn setText
}//end CharacterController
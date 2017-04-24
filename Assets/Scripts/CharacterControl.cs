/*
Debug.LogError("Message");
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl: MonoBehaviour
{
    public GameObject BaseChip;
    //public float speed;
    public bool inGame;
    private bool readyGame;
    private float speed;

    public Camera[] cameras;
    public Canvas[] canvasses;
    private int currentCameraIndex;
    private int tempCameraIndex;

    public Text walletText;
    public Text StartGameText;

    public int wallet;

    // Use this for initialization
    void Start()
    {
        wallet = 300;


        Cursor.lockState = CursorLockMode.Locked;
        speed = 7.0f;
        inGame = false;
        readyGame = false;

        setText(false);

        currentCameraIndex = 0;

        setCamera();
        setCanvas();
        /*
        //Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
            //canvasses[i].GetComponent<CanvasRenderer>().enabled = false;
            canvasses[i].gameObject.SetActive(false);

        }

        //If any cameras were added to the controller, enable the first one
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            //Debug.Log("Camera with name: " + cameras[0].camera.name + ", is now enabled");
        }
        */
    }//end Start

    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {
            switch (currentCameraIndex)
            {
                case 1:
                {
                        GameObject.Find("Roulette").GetComponent<RouletteGame>().updateSelf();
                        break;
                }//end case 1
                case 2:
                {
                        GameObject.Find("Slots").GetComponent<Slotgame>().updateSelf();
                        break;
                }//end case 2
                case 3:
                {

                    break;
                }//end case 3
                default:
                {
                    Debug.LogError("Invalid Camera Index");
                    break;
                }//end default
            }//end switch

            if (Input.GetKeyDown(KeyCode.Q))
            {
                endGame();
                currentCameraIndex = 0;

                setCamera();
                setCanvas();
                inGame = false;
                Cursor.lockState = CursorLockMode.Locked;
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
                startGame();

                setCamera();
                setCanvas();
                inGame = true;
                Cursor.lockState = CursorLockMode.None;

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
            tempCameraIndex = other.transform.parent.GetComponent<GameStartVars>().gameIndex;

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

    void startGame()
    {
		GameObject temp;

        switch (currentCameraIndex)
        {
            case 1:
            {
                    //ScriptName sn = gameObject.GetComponent<ScriptName>()
                    //sn.DoSomething();
                    temp = GameObject.Find("Roulette");
				temp.GetComponent<RouletteGame>().startSelf();
                break;
            }//end case 1
            case 2:
            {

				temp = GameObject.Find("Slots");
				temp.GetComponent<Slotgame>().startSelf();
                break;
            }//end case 2
            case 3:
            {

                break;
            }//end case 3
            default:
            {

                break;
            }//end default
        }//end switch
    }//end setupGame

    void endGame()
    {
        GameObject temp;

        switch (currentCameraIndex)
        {
            case 1:
            {
                temp = GameObject.Find("Roulette");
                temp.GetComponent<RouletteGame>().endSelf();
                break;
            }//end case 1
            case 2:
            {
				/*temp = GameObject.Find ("Slots");
				temp.GetComponent<Slotgame>().endSelf ();*/
                break;
            }//end case 2
            case 3:
            {

                break;
            }//end case 3
            default:
            {

                break;
            }//end default
        }//end switch

        if(wallet < 1)
        {
            looseChips();
        }
    }//end setupGame

    void setCamera()
    {
        for(int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }//end for

        cameras[currentCameraIndex].gameObject.SetActive(true);
    }//end set camera

    void setCanvas()
    {
        for (int i = 0; i < canvasses.Length; i++)
        {
            canvasses[i].gameObject.SetActive(false);
        }//end for

        canvasses[currentCameraIndex].gameObject.SetActive(true);
    }//end setCanvas

    void buyPrize()
    {


    }

    private void looseChips()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject localChip = Instantiate(BaseChip) as GameObject;

            localChip.GetComponent<ChipDynamics>().pickupChip(2, transform.position + new Vector3(UnityEngine.Random.Range(-2.0f, 2.0f), 2, UnityEngine.Random.Range(-2.0f, 2.0f)), new Quaternion());
        }
    }


    void setWallet()
    {
            walletText.text = "Wallet = " + wallet;
    }//edn setText

    void setText(bool show)
    {
        if(show)
        {
            StartGameText.text = "Press 'e' to play game";
        }//end if
        else
        {
            StartGameText.text = " ";
        }//edn else
    }//end setText
}//end CharacterController
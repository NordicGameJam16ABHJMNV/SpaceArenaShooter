using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputController : MonoBehaviour
{
    //Use this to handle inputs and call into the other scripts on the spaceships


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameLogic initGameScript = GameObject.Find("Game").GetComponent<GameLogic>();

        for (int i = 0; initGameScript.getPlayerCount() > i; i++)
        {
            GameObject playerShip = GameObject.Find("Player_" + i);
            if (playerShip != null)
            {
                PlayerController script = playerShip.GetComponent<PlayerController>();

                if (i == 3)
                {
                    float horizontal = 0.0f;
                    float vertical = 0.0f;
                    if (Input.GetKey("w"))
                    {
                        horizontal = 1.0f;
                    }
                    else
                    {
                        if (Input.GetKey("s"))
                        {
                            horizontal = -1.0f;
                        }
                    }

                    if (Input.GetKey("a"))
                    {
                        vertical = -1.0f;
                    }
                    else
                    {
                        if (Input.GetKey("d"))
                        {
                            vertical = 1.0f;
                        }
                    }

                    Vector2 input = new Vector2(vertical, horizontal);
                    script.Move(input);
                    if (Input.GetKey("space"))
                    {
                        script.Shoot();
                    }

                }
                else
                {
                    Vector2 input = new Vector2(Input.GetAxis("HorizontalP" + (i + 1)), Input.GetAxis("VerticalP" + (i + 1)));

                    script.Move(input);
                    if (Input.GetKey("joystick " + (i + 1) + " button 0"))
                    {
                        script.Shoot();
                    }
                }
            }
        }

        //Pressing the start button
        if (Input.GetKeyDown("joystick button 7"))
        {
            GameObject.Find("Game").GetComponent<GameLogic>().GameOver();
        }

    }
}

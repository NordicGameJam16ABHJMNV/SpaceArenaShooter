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
        InitGame initGameScript = GameObject.Find("Game").GetComponent<InitGame>();
        List<Player> players = initGameScript.getPlayers();

        for (int i = 0; initGameScript.getPlayerCount()-1 > i; i++)
        {
            PlayerController script = players[i].Ship.GetComponent<PlayerController>();

            Vector2 input = new Vector2(Input.GetAxis("HorizontalP" + (i + 1)), Input.GetAxis("VerticalP" + (i + 1)));

            script.Move(input);
            if (Input.GetKey("joystick " + (i + 1) + " button 0"))
            {
                script.Shoot();
            }
        }

    }
}

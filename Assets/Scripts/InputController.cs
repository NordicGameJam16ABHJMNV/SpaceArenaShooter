using UnityEngine;
using System.Collections;

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

        for (int i = 0; i < 4; i++)
        {
            //GameObject obj = GameObject.Find("Spaceship_" + (i));

            //PlayerController script = obj.GetComponent<PlayerController>();

            Vector2 input = new Vector2(Input.GetAxis("HorizontalP" + (i + 1)), Input.GetAxis("VerticalP" + (i + 1)));

            //script.Move(input);
            if (Input.GetKey("joystick " + (i + 1) + " button 0"))
            {
              //  script.Shoot();
            }
        }

    }
}

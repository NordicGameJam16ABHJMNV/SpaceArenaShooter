using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float timeToMaxSpeed = 1f;

    private float velocity = 0f; //TODO: MAKE CALCULATION!
    private float friction;


    // MaxSpeed = velocity/friction
    // Time to max speed = 2.0/friction
    // velocity = acceleration / fiction

    //velocity =+ acceleration * deltatime
    //velocity =- velocity * friction * deltatime


    // Use this for initialization
    void Start()
    {
        friction = 2.0f / timeToMaxSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        int acceleration;

    }
}

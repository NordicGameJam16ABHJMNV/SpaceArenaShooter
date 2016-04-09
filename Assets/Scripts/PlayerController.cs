using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    
    public float friction = 1;
    public float acceleration = 10;

    private Rigidbody2D body;

   
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        //Movement is called by InputController script
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Move(new Vector2(xInput, yInput));
#endif
    }

    internal void Move(Vector2 input)
    {
        body.velocity -= body.velocity * friction * Time.deltaTime;

        body.velocity += input * acceleration * Time.deltaTime;
    }
}

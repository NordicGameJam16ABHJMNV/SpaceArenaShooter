using UnityEngine;
using System.Collections;

public class AirTankLogic : MonoBehaviour {

    private int Holes;
    public float Air = 1000;
    public float AirConsuming = 0.1f;

	// Use this for initialization
	void Start () {
        Holes = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Air < 0)
        {
            //GameOverCalled
        }
        //Consumes Air
        Air =- AirConsuming + Holes * AirConsuming;
        //Updates Container
	}
}

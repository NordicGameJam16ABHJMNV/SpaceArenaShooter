using UnityEngine;
using System.Collections;

public class AirTankLogic : MonoBehaviour {

    public GameObject SpaceShip;
    private int Holes;
    public float Air = 1000;
    public float AirConsuming = 0.1f;

    public void Init(GameObject SpaceShip, float Air)
    {
        this.SpaceShip = SpaceShip;
        this.Air = Air;
    }

	// Use this for initialization
	void Start () {
        Holes = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Air < 0)
        {
            Destroy(GetComponent<GameObject>());
        }
        //Consumes Air
        Air -= AirConsuming + Holes * AirConsuming;
        //Updates Container
	}

    public void AddHole(int Number)
    {
        Holes += Number;
    }

    public void CloseHole(int Number)
    {
        if (Holes >= Number)
        Holes -= Number;
    }
}

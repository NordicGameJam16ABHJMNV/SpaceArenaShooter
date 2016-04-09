using UnityEngine;
using System.Collections.Generic;

public class InitGame : MonoBehaviour {

    public GameObject SpaceShip;
    public GameObject PlayerGUI;
    private int PlayerCount = 1;
    private List<Player> Players = new List<Player>();

    // Use this for initialization
    void Start() {
        Players.Add(new Player()
        {
            PlayerID = PlayerCount,
            Ship = Instantiate(SpaceShip, new Vector3(0f, 0f), Quaternion.identity) as GameObject,
            GUI = Instantiate(PlayerGUI, new Vector3(0f, 0f), Quaternion.identity) as GameObject,
        });
        PlayerCount++;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (0 != 0)
            Players.Add(new Player()
            {
                PlayerID = PlayerCount,
                Ship = Instantiate(SpaceShip, new Vector3(0f, 0f), Quaternion.identity) as GameObject,
                GUI = Instantiate(PlayerGUI, new Vector3(0f, 0f), Quaternion.identity) as GameObject,
            });
        PlayerCount++;
    }

    //Return Current Players
    public List<Player> getPlayers()
    {
        return Players;
    }

    //Return Number of Current Players
    public int getPlayerCount()
    {
        return PlayerCount;
    }
}

public class Player
{
    public int PlayerID { get; set; }
    public GameObject Ship { get; set; }
    public GameObject GUI { get; set; }
}

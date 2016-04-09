using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InitGame : MonoBehaviour {

    public GameObject SpaceShip;
    public GameObject PlayerGUI;
    public GameObject gui;
    public List<Vector3> PlayerPossition;


    public int PlayerCount = 1;
    private List<Player> Players = new List<Player>();
    private Button myButton;
    

    void Awake()
    {
        myButton = GameObject.Find("Start").GetComponent<Button>();
        myButton.onClick.AddListener(Init);
    }

    // Use this for initialization
    void Init() {
        gui.SetActive(false);
        PlayerCount++;

        Players.Add(new Player()
        {
            PlayerID = PlayerCount,
            Ship = Instantiate(SpaceShip, PlayerPossition[PlayerCount -1], Quaternion.identity) as GameObject,
            GUI = Instantiate(PlayerGUI, PlayerPossition[PlayerCount - 1], Quaternion.identity) as GameObject,
        });
    }

    // Update is called once per frame
    void FixedUpdate() {
        while (PlayerCount < 5 && PlayerCount > 1) { 
            Players.Add(new Player()
            {
                PlayerID = PlayerCount,
                Ship = Instantiate(SpaceShip, PlayerPossition[PlayerCount - 1], Quaternion.identity) as GameObject,
                GUI = Instantiate(PlayerGUI, PlayerPossition[PlayerCount - 1], Quaternion.identity) as GameObject,
            });
        PlayerCount++;
        }
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

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InitGame : MonoBehaviour {

    public GameObject SpaceShip;
    public GameObject PlayerGUI;
    public GameObject GUI;
    public List<Vector3> PlayerPossition;


    private int PlayerCount = 1;
    private List<Player> Players = new List<Player>();
    private Button myButton;
    

    void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(Init);
    }

    // Use this for initialization
    void Init() {
        GUI.SetActive(false);
        Players.Add(new Player()
        {
            PlayerID = PlayerCount,
            Ship = Instantiate(SpaceShip, PlayerPossition[PlayerCount -1], Quaternion.identity) as GameObject,
            GUI = Instantiate(PlayerGUI, PlayerPossition[PlayerCount - 1], Quaternion.identity) as GameObject,
        });
        PlayerCount++;
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

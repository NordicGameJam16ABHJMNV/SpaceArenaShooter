using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameLogic: MonoBehaviour
{
    //PlayerCreation
    public GameObject SpaceShip;
    public List<Vector3> PlayerPossition = new List<Vector3>(4);
    private int PlayerCount = 0;
    private List<Player> Players = new List<Player>();
    private Button myButton;

    //GUI
    public GameObject PlayerGUI;
    public List<Vector3> PlayerGuiPosition = new List<Vector3>(4);
    private Text TitleText;
    private Text StartText;
    private GameObject gui;
    private bool hasBooted = false;

    //OtherAssets
    public GameObject Astroids;

    void Start()
    {
        StartText = GameObject.Find("StartText").GetComponent<Text>();
        TitleText = GameObject.Find("TitleText").GetComponent<Text>();
        gui = GameObject.Find("StartGUI");

        myButton = GameObject.Find("Start").GetComponent<Button>();
        myButton.onClick.AddListener(Init);
    }

    // Update is called once per frame
    void Update()
    {
        while (PlayerCount < 4 && PlayerCount > 0)
        {
            CreatePlayer();
        }
        if (hasBooted)
        {
            int remainingPlayers = 0;
            string lastPlayer = "";
            for (int i = 0; i < 4; i++)
            {
                if (GameObject.Find("Player_" + i) != null)
                {
                    remainingPlayers++;
                    lastPlayer = "Player " + (i+1) + " is the last survivor!";
                }
            }

            if (remainingPlayers < 2)
            {
                
                GameOver(lastPlayer);
            }
        }
        else
        {
            if (GameObject.Find("Player_3") != null)
            {
                hasBooted = true;
            }
        }
    }

    // Use this for initialization
    void Init()
    {
        gui.SetActive(false);
        CreatePlayer();
    }

    //Creating Players
    void CreatePlayer()
    {
        Player player = new Player()
        {
            Ship = Instantiate(SpaceShip, PlayerPossition[PlayerCount], Quaternion.identity) as GameObject,
            Gui = Instantiate(PlayerGUI, PlayerGuiPosition[PlayerCount], Quaternion.identity) as GameObject,
        };
        Players.Add(player);
        Players[PlayerCount].Ship.name = "Player_" + PlayerCount;
        Players[PlayerCount].Gui.name = "PlayerGui_" + PlayerCount;
        Players[PlayerCount].Ship.GetComponent<PlayerController>().Init(Players[PlayerCount].Gui, 1000f);
        PlayerCount++;
    }

    //GameOver or Win
    public void GameOver(string resetReason)
    {
        hasBooted = false;
        for (var i = 0; i < PlayerCount; i++)
        {
            Destroy(Players[i].Gui);
            Destroy(Players[i].Ship);
        }
        Debug.Log(resetReason);
        Players.Clear();
        PlayerCount = 0;
        string newTitleText = "Game Over. " + resetReason;
        TitleText.text = newTitleText;
        gui.SetActive(true);
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

    //Comets Drop
    void CometCreator()
    {
       GameObject a = Instantiate(Astroids, new Vector3((float)Random.Range(-(Screen.width/2),Screen.width/2),(float)Random.Range(Screen.height, Screen.height)), Quaternion.identity) as GameObject;
        var size = Random.Range(100, 300);
        a.GetComponent<Transform>().localScale = new Vector3(size,size,size);
        //a.GetComponent<Rigidbody>().velocity
    }

    //PowerUps
    void PowerUps()
    {
        //TODO
    }
}

public class Player
{
    public GameObject Ship { get; set; }
    public GameObject Gui { get; set; }
}
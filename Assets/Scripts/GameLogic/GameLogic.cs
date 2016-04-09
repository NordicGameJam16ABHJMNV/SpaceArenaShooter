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
    private Text QuitText;
    private GameObject gui;

    void Start()
    {
        StartText = GameObject.Find("StartText").GetComponent<Text>();
        QuitText = GameObject.Find("QuitText").GetComponent<Text>();
        TitleText = GameObject.Find("TitleText").GetComponent<Text>();
        gui = GameObject.Find("StartGUI").GetComponent<GameObject>();

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
        Players.Add(new Player()
        {
            PlayerID = PlayerCount,
            Ship = Instantiate(SpaceShip, PlayerPossition[PlayerCount], Quaternion.identity) as GameObject,
            GUI = Instantiate(PlayerGUI, PlayerGuiPosition[PlayerCount], Quaternion.identity) as GameObject,
        });
        PlayerCount++;
    }

    //GameOver or Win
    public void GameOver()
    {
        for (var i = 0; i <= PlayerCount; i++)
        {
            Destroy(Players[i].GUI);
            Destroy(Players[i].Ship);
        }
        PlayerCount = 0;
        TitleText.text = "Game Over";
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
    void Comeths()
    {
        //TODO
    }

    //PowerUps
    void PowerUps()
    {
        //TODO
    }
}

public class Player
{
    public int PlayerID { get; set; }
    public GameObject Ship { get; set; }
    public GameObject GUI { get; set; }
}
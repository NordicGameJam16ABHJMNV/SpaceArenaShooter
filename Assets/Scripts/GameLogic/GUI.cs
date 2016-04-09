using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI : MonoBehaviour
{
    private GameObject gui;
    //Initiate New Game
    void InitGame()
    {
        gui = GetComponent<GameObject>();
    }

    //GameOver or Win
    public void GameOver()
    {
        var text = GetComponentInChildren<Text>();
        gui.SetActive(true);
    }

    //Air Tank
    void AirTank()
    {
        //TODO
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

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TurnManager : MonoBehaviour
{

    private static TurnManager instance;
    [SerializeField] private PlayerTurn player1;
    [SerializeField] private PlayerTurn player2;
    [SerializeField] private GameObject Cam1;
    [SerializeField] private GameObject Cam2;

    //Timer
    //[SerializeField] private Image clock;
    [SerializeField] public float timeRemaining;

    //Timer not active
    public bool timerIsRunning = false;


    //Active or waiting player
    private int currentPlayerIndex;
    public bool waitingForNextTurn;

    public GameObject PanelP1;
    public GameObject PanelP2;

    private void Awake()
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        PanelP1.gameObject.SetActive(true);
        PanelP2.gameObject.SetActive(false);

        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            player1.SetPlayerTurn(1);
            player2.SetPlayerTurn(2);
        }
    }
    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return false;
        }

        return index == currentPlayerIndex;
    }

    private void Start()
    {
        //Activate Timer
        timerIsRunning = true;
    }

    public void Update()
    {
        if (timerIsRunning)
        {
            //clock.fillAmount = (timeRemaining);
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                if (waitingForNextTurn)
                {
                    waitingForNextTurn = false;
                    ChangeTurn();
                }
                else
                {
                    ChangeTurn();
                    timeRemaining += 15;
                    timerIsRunning = true;
                }
            }

        }

    }


    private void ResetTimer()
    {

    }




    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    private void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
            Cam1.SetActive(false);
            Cam2.SetActive(true);

            Cam2.GetComponent<AudioListener>().enabled = true;
            Cam1.GetComponent<AudioListener>().enabled = false;

            PanelP1.gameObject.SetActive(false);
            PanelP2.gameObject.SetActive(true);
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
            Cam1.SetActive(true);
            Cam2.SetActive(false);

            Cam1.GetComponent<AudioListener>().enabled = true;
            Cam2.GetComponent<AudioListener>().enabled = false;

            PanelP2.gameObject.SetActive(false);
            PanelP1.gameObject.SetActive(true);
        }

    }
    /*
    private void GameOver()
    {
        if (Player1 = isDead)
        {
            Trigger GameOverScene
            Show winner p2_logo
        }
        else if (player2 = isDead)
        {
            Trigger GameOverScene
            Show winner p1_logo
        }

    }
    */
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Timer : MonoBehaviour
{
    
    private static TurnManager instance;
    [SerializeField] private PlayerTurn player1;
    [SerializeField] private PlayerTurn player2;
    [SerializeField] public float timeRemaining;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            player1.SetPlayerTurn(1);
            player2.SetPlayerTurn(2);
        }

    }

    private void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
        }
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            ChangeTurn();
        }
        //Här vill man ha en retart timeremaining
    }
}*/

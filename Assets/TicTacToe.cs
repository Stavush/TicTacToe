using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = System.Random;

public class TicTacToe : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI turnText;
    public Button[] buttons;
    private bool isPlayerX = true;

    private int[] board = new int[9]; // Optional values: 0 = Empty, 1 = Player X, 2 = Player O

    void Start()
    {
        InitializeBoard();
    }

    // A method that sets up the board by adding onButtonClick() event listeners
    void InitializeBoard()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
            buttons[i].interactable = true;
        }

        winnerText.text = "";
        turnText.text = "Player X's turn";
    }


    // A method that handles the event of button click
    void OnButtonClick(int index)
    {
        if (board[index] == 0)
        {
            board[index] = isPlayerX ? 1 : 2;
            buttons[index].GetComponentInChildren<TextMeshProUGUI>().text = isPlayerX ? "X" : "O";
            buttons[index].interactable = false;

            if (IsWinDetected())
            {
                string winner = isPlayerX ? "Player X" : "Player O";
                winnerText.text = winner + " is the winner!";
                turnText.text = "";
                foreach (Button button in buttons)
                {
                    button.interactable = false;
                }
            }
            else if (IsBoardFull())
            {
                winnerText.text = "It's a tie!";
                turnText.text = "";
            }
            else
            {
                isPlayerX = !isPlayerX;
                turnText.text = isPlayerX ? "Player X's turn" : "Player O's turn";
            }
        }
    }

    // A method that holds the computer turn logic
    string ComputerTurn()
    {
        int rndIndex = PickRandomIndex();
        buttons[rndIndex].interactable = false;
        board[rndIndex] = 2;
        return "0";
    }


    // A method that randomly picks an available button on the board
    int PickRandomIndex()
    {
        Random random = new Random();
        while (true)
        {
            int randomIndex = random.Next(0, 10);
            if (board[randomIndex] == 0)
            {
                return randomIndex;
            }
        }
    }

    bool IsWinDetected()
    {
        if (board[0] == board[4] && board[4] == board[8] && board[0]!=0)
        {
            return true;
        }
        else if (board[2] == board[4] && board[4] == board[6] && board[2]!=0)
        {
            return true;
        }
        else if (board[0] == board[1] && board[1] == board[2] && board[0]!=0)
        {
            return true;
        }
        else if (board[3] == board[4] && board[4] == board[5] && board[3] != 0)
        {
            return true;
        }
        else if (board[6] == board[7] && board[7] == board[8] && board[6] != 0)
        {
            return true;
        }
        else if (board[0] == board[3] && board[3] == board[6] && board[0] != 0)
        {
            return true;
        }
        else if (board[1] == board[4] && board[4] == board[7] && board[1] != 0)
        {
            return true;
        }
        else if (board[2] == board[5] && board[5] == board[8] && board[2] != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsBoardFull()
    {
        return !Array.Exists(board, element => element == 0);
    }
}
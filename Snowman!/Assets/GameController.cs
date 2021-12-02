using WordGuesser;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public UnityEngine.UI.Text Message;
    public UnityEngine.UI.Text GetGuessedLetter;
    public UnityEngine.UI.Text GuessesRemaining;
    public UnityEngine.UI.Text CheckGuess;
    public UnityEngine.UI.Text GetWord;
    public UnityEngine.UI.Button StartButton;
    public GameObject StartScreen;
    public GameObject PlayScreen;
    private WordGuesser.WordGame guessingGame;
    public UnityEngine.UI.InputField PlayerGuess;

    public void StartGame()
    {
        this.guessingGame = new WordGuesser.WordGame("apple", 5);
        Debug.Log(this.guessingGame.GetWord());
        Debug.Log(this.guessingGame.GetFullWord());
        this.Message.text = "Can you save the Snowman?";
        this.StartButton.gameObject.SetActive(false);
        this.StartScreen.SetActive(false);
        this.PlayScreen.SetActive(true);
    }

    public void OpenStartScreen()
    {
        this.StartScreen.SetActive(false);
        this.PlayScreen.SetActive(true);
    }

    public void Start()
    {
        this.StartScreen.SetActive(true);
        this.PlayScreen.SetActive(false);
    }

    public void SubmitGuess()
    {
        string guess = PlayerGuess.text;
        CheckGuess.text = this.guessingGame.CheckGuess(PlayerGuess.text);

        Debug.Log(guess);
        GetWord.text = this.guessingGame.GetWord();
        PlayerGuess.text = string.Empty;
        
        if (this.guessingGame.IsGameOver())
        {
            this.ShowGameOverScreen();
        }
        if (this.guessingGame.IsGameWon())
        {
            this.ShowGameWonScreen();
        }
    }
}



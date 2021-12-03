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
    public UnityEngine.UI.Text PlayerWon;
    public UnityEngine.UI.Text PlayerLost;
    public UnityEngine.UI.Button StartButton;
    public GameObject StartScreen;
    public GameObject PlayScreen;
    public GameObject GameOverScreen;
    public GameObject GameWonScreen;
    private WordGuesser.WordGame guessingGame;
    public UnityEngine.UI.InputField PlayerGuess; 

    public void StartGame()
    {
        string words = UnityEngine.Resources.Load<TextAsset>("words").text;
        WordSelector selector = WordSelector.LoadFromString(words);
        this.guessingGame = new WordGuesser.WordGame(selector.GetWord(), 5);
        Debug.Log(this.guessingGame.GetWord());
        Debug.Log(this.guessingGame.GetFullWord());
        // this.Message.text = "Can you save the Snowman?";
        // this.StartButton.gameObject.SetActive(false);

        CheckGuess.text = "Guess A Letter";
        GetWord.text = this.guessingGame.GetWord();
        GetGuessedLetter.text = $"Guessed letters: {this.guessingGame.GetGuessedLetters()}";
        GuessesRemaining.text = $" Number of Remaining Guesses: {this.guessingGame.GetGuessLimit() - this.guessingGame.GetIncorrectGuesses()}";
       
        this.StartScreen.SetActive(false);
        this.PlayScreen.SetActive(true);
        this.GameOverScreen.SetActive(false);
        this.GameWonScreen.SetActive(false);
    }
    
    public void OpenStartScreen()
    {
        this.StartScreen.SetActive(true);
        this.PlayScreen.SetActive(false);
        this.GameOverScreen.SetActive(false);
        this.GameWonScreen.SetActive(false);
    }

    public void Start()
    {
        this.StartScreen.SetActive(true);
        this.PlayScreen.SetActive(false);
        this.GameOverScreen.SetActive(false);
        this.GameWonScreen.SetActive(false);
    }

    public void SubmitGuess()
    {
       string guess = PlayerGuess.text;
        CheckGuess.text = this.guessingGame.CheckGuess(PlayerGuess.text);

        Debug.Log(guess);
        GetWord.text = this.guessingGame.GetWord();
        GetGuessedLetter.text = $"Guessed letters: {this.guessingGame.GetGuessedLetters()}";
        GuessesRemaining.text = $" Number of Remaining Guesses: {this.guessingGame.GetGuessLimit() - this.guessingGame.GetIncorrectGuesses()}";
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

    public void ShowGameOverScreen()
    {
    PlayerLost.text = $"You lost! The word was {this.guessingGame.GetFullWord()}";
    this.StartScreen.SetActive(false);
    this.PlayScreen.SetActive(false);
    this.GameWonScreen.SetActive(false);
    this.GameOverScreen.SetActive(true);
    }

    public void ShowGameWonScreen()
    {
    PlayerWon.text = $"You won!";
    this.StartScreen.SetActive(false);
    this.PlayScreen.SetActive(false);
    this.GameWonScreen.SetActive(true);
    this.GameOverScreen.SetActive(false);   
    }
}


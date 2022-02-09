using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool gameStarted;
    public int score = 0;
    public int highScore = 0;

    public Text currentScore;
    public Text currenthighScore;

    public void Awake()
    {
        currenthighScore.text = $"HIGH SCORE: {GetHighScore()}";
    }

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<RoadGenerator>().StartBuilding();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<MusicLoop>().StopMusic();
            SceneManager.LoadScene("Title");
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void IncreaseScore()
    {
        score++;

        currentScore.text = $"Current Score: {score}";

        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

    public int GetHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("Highscore");
        return savedHighScore;
    }
}

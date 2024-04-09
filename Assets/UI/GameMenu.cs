using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    
    public GameObject playAgain;
    public GameObject nextLevel;

    private void Awake()
    {
        buttonGame();
    }

    private void Update()
    {
        if (GameManager.Instance.countBlock == 0)
        {
            _playAgain();
            _nextLevel();
        }

        if (GameManager.Instance.lives == 0)
        {
            Time.timeScale = 0f;
            _playAgain();
        }
    }

    void buttonGame()
    {
        playAgain.SetActive(false);
        nextLevel.SetActive(false);
    }

    void _playAgain()
    {
        playAgain.SetActive(true);
    }

    void _nextLevel()
    {
        nextLevel.SetActive(true);
    }

    public void clickNext()
    {
        if (GameManager.Instance.level == 2)
        {
            GameManager.Instance.countBlock = 40;
        }
        
        if (GameManager.Instance.level <= 2)
        {
            GameManager.Instance.countBlock = 50;
            SceneManager.LoadScene("Level"+GameManager.Instance.level);
            GameManager.Instance.level += 1;
            GameManager.Instance.lives = 2;
        }
        else
        {
            GameManager.Instance.countBlock = 60;
            SceneManager.LoadScene("SampleScene");
            GameManager.Instance.level = 1;
            GameManager.Instance.lives = 2;
        }
    }

    public void clickAgain()
    {
        GameManager.Instance.countBlock = 60;
        GameManager.Instance.lives = 2;
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}

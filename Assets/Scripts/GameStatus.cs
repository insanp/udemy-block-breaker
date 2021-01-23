using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] float gameSpeed;
    [SerializeField] int currentScore;

    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] bool autoPlay;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    internal bool IsAutoPlay()
    {
        return autoPlay;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        currentScoreText.text = currentScore.ToString();
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public int GetScore()
    {
        return currentScore;
    }
}

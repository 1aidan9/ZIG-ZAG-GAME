﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public static UiManager instance; 

    public GameObject titlePanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore1; 
    public Text highScore2; 

    void Awake()
    {
        if (instance == null) 
            instance = this; 
    }

	
	void Start () {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }
	
	
	void Update () {
		
	}

    public void GameStart()
    {
        tapText.SetActive(false);
        titlePanel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0); 
    }
}

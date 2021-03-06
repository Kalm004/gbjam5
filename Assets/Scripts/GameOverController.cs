﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
    public GameObject retryButton;
    public GameObject levelSelectButton;
    public GameObject exitButton;
    public GameObject selector;
    private LevelController levelController;

    enum Options
    {
        Retry,
        LevelSelect,
        Exit
    }

    Options selectedOption = Options.Retry;

    // Use this for initialization
    void Start () {
        levelController = Camera.main.GetComponent<LevelController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (selectedOption)
            {
                case Options.Retry:
                    selectedOption = Options.LevelSelect;
                    break;
                case Options.LevelSelect:
                    selectedOption = Options.Exit;
                    break;
                case Options.Exit:
                    selectedOption = Options.Retry;
                    break;
                default:
                    break;
            }
            moveSelector();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (selectedOption)
            {
                case Options.Retry:
                    selectedOption = Options.Exit;
                    break;
                case Options.LevelSelect:
                    selectedOption = Options.Retry;
                    break;
                case Options.Exit:
                    selectedOption = Options.LevelSelect;
                    break;
                default:
                    break;
            }
            moveSelector();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (selectedOption)
            {
                case Options.Retry:
                    SceneManager.LoadScene(Scenes.Level + levelController.levelNumber.ToString());
                    break;
                case Options.LevelSelect:
                    SceneManager.LoadScene(Scenes.LevelSelection);
                    break;
                case Options.Exit:
                    SceneManager.LoadScene(Scenes.MainMenu);
                    break;
                default:
                    break;
            }
        }
	}
    private void moveSelector()
    {
        switch (selectedOption)
        {
            case Options.Retry:
                selector.transform.position = new Vector3(selector.transform.position.x, retryButton.transform.position.y);
                break;
            case Options.LevelSelect:
                selector.transform.position = new Vector3(selector.transform.position.x, levelSelectButton.transform.position.y);
                break;
            case Options.Exit:
                selector.transform.position = new Vector3(selector.transform.position.x, exitButton.transform.position.y);
                break;
            default:
                break;
        }
    }
}

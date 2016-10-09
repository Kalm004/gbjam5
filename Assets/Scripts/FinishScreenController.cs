using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishScreenController : MonoBehaviour {
    public GameObject nextLevelButton;
    public GameObject levelSelectButton;
    public GameObject exitButton;
    public GameObject selector;
    public Image[] gemIndicators;
    public Sprite gemFull;
    public Text title;
    private LevelController levelController;

    enum Options
    {
        NextLevel,
        LevelSelect,
        Exit
    }

    Options selectedOption = Options.NextLevel;

    // Use this for initialization
    void Start () {
        levelController = Camera.main.GetComponent<LevelController>();
        int gems = levelController.getGemStones();
        for (int i = 0; i < gems; i++)
        {
            gemIndicators[i].sprite = gemFull;
        }
        title.text = "Level " + levelController.levelNumber + " complete!";
        if (levelController.levelNumber == GameManager.levelCount)
        {
            nextLevelButton.SetActive(false);
            selectedOption = Options.LevelSelect;
        }
        moveSelector();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (selectedOption)
            {
                case Options.NextLevel:
                    selectedOption = Options.LevelSelect;
                    break;
                case Options.LevelSelect:
                    selectedOption = Options.Exit;
                    break;
                case Options.Exit:
                    if (levelController.levelNumber == GameManager.levelCount)
                    {
                        selectedOption = Options.LevelSelect;
                    }
                    else
                    {
                        selectedOption = Options.NextLevel;
                    }
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
                case Options.NextLevel:
                    selectedOption = Options.Exit;
                    break;
                case Options.LevelSelect:
                    if (levelController.levelNumber == GameManager.levelCount)
                    {
                        selectedOption = Options.Exit;
                    }
                    else
                    {
                        selectedOption = Options.NextLevel;
                    }
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
                case Options.NextLevel:
                    SceneManager.LoadScene(Scenes.Level + (levelController.levelNumber + 1).ToString());
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
            case Options.NextLevel:
                selector.transform.position = new Vector3(selector.transform.position.x, nextLevelButton.transform.position.y);
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

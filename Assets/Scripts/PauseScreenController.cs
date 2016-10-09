using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreenController : MonoBehaviour {
    public GameObject resumeButton;
    public GameObject levelSelectButton;
    public GameObject exitButton;
    public GameObject selector;
    public Image[] gemIndicators;
    public Sprite gemFull;
    private LevelController levelController;

    enum Options
    {
        Resume,
        LevelSelect,
        Exit
    }

    Options selectedOption = Options.Resume;

    // Use this for initialization
    void Start () {
        levelController = Camera.main.GetComponent<LevelController>();
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < levelController.getGemStones(); i++)
        {
            gemIndicators[i].sprite = gemFull;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (selectedOption)
            {
                case Options.Resume:
                    selectedOption = Options.LevelSelect;
                    break;
                case Options.LevelSelect:
                    selectedOption = Options.Exit;
                    break;
                case Options.Exit:
                    selectedOption = Options.Resume;
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
                case Options.Resume:
                    selectedOption = Options.Exit;
                    break;
                case Options.LevelSelect:
                    selectedOption = Options.Resume;
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
            Time.timeScale = 1;
            switch (selectedOption)
            {
                case Options.Resume:
                    gameObject.SetActive(false);
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
            case Options.Resume:
                selector.transform.position = new Vector3(selector.transform.position.x, resumeButton.transform.position.y);
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

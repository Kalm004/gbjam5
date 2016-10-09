using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public GameObject playButton;
    public GameObject helpButton;
    public GameObject exitButton;
    public GameObject selector;

    enum Options
    {
        Play,
        Help,
        Exit
    }

    Options selectedOption = Options.Play;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (selectedOption)
            {
                case Options.Play:
                    selectedOption = Options.Help;        
                    break;
                case Options.Help:
                    selectedOption = Options.Exit;
                    break;
                case Options.Exit:
                    selectedOption = Options.Play;
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
                case Options.Play:
                    selectedOption = Options.Exit;
                    break;
                case Options.Help:
                    selectedOption = Options.Play;
                    break;
                case Options.Exit:
                    selectedOption = Options.Help;
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
                case Options.Play:
                    SceneManager.LoadScene(Scenes.LevelSelection);
                    break;
                case Options.Help:
                    SceneManager.LoadScene(Scenes.Help);
                    break;
                case Options.Exit:
                    Application.Quit();
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
            case Options.Play:
                selector.transform.position = new Vector3(selector.transform.position.x, playButton.transform.position.y);
                break;
            case Options.Help:
                selector.transform.position = new Vector3(selector.transform.position.x, helpButton.transform.position.y);
                break;
            case Options.Exit:
                selector.transform.position = new Vector3(selector.transform.position.x, exitButton.transform.position.y);
                break;
            default:
                break;
        }
    }
}

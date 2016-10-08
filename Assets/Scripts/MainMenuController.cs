using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public GameObject playButton;
    public GameObject exitButton;
    public GameObject selector;

    enum Options
    {
        Play,
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
            selectedOption = Options.Exit;
            selector.transform.position = new Vector3(selector.transform.position.x, exitButton.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedOption = Options.Play;
            selector.transform.position = new Vector3(selector.transform.position.x, playButton.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (selectedOption)
            {
                case Options.Play:
                    SceneManager.LoadScene(Scenes.LevelSelection);
                    break;
                case Options.Exit:
                    Application.Quit();
                    break;
                default:
                    break;
            }
        }
	}
}

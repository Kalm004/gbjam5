using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HelpScreenController : MonoBehaviour {
    public GameObject backButton;
    public GameObject creditsButton;
    public GameObject selector;
    enum Options
    {
        Back,
        Credits
    }

    Options selectedOption = Options.Back;

    // Use this for initialization
    void Start () {
	
	}


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (selectedOption)
            {
                case Options.Back:
                    selectedOption = Options.Credits;
                    break;
                case Options.Credits:
                    selectedOption = Options.Back;
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
                case Options.Back:
                    selectedOption = Options.Credits;
                    break;
                case Options.Credits:
                    selectedOption = Options.Back;
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
                case Options.Back:
                    SceneManager.LoadScene(Scenes.MainMenu);
                    break;
                case Options.Credits:
                    SceneManager.LoadScene(Scenes.Credits);
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
            case Options.Back:
                selector.transform.position = new Vector3(selector.transform.position.x, backButton.transform.position.y);
                break;
            case Options.Credits:
                selector.transform.position = new Vector3(selector.transform.position.x, creditsButton.transform.position.y);
                break;
            default:
                break;
        }
    }
}

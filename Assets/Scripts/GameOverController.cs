using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
    public GameObject retryButton;
    public GameObject levelSelectButton;
    public GameObject selector;

    enum Options
    {
        Retry,
        LevelSelect
    }

    Options selectedOption = Options.Retry;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedOption = Options.LevelSelect;
            selector.transform.position = new Vector3(selector.transform.position.x, levelSelectButton.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedOption = Options.Retry;
            selector.transform.position = new Vector3(selector.transform.position.x, retryButton.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (selectedOption == Options.Retry)
            {
                SceneManager.LoadScene("Scene1");
            }
        }
	}
}

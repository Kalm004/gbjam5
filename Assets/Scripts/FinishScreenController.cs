using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishScreenController : MonoBehaviour {
    public GameObject nextLevelButton;
    public GameObject levelSelectButton;
    public GameObject selector;
    public Image[] gemIndicators;
    public Sprite gemFull;
    public Text title;

    enum Options
    {
        NextLevel,
        LevelSelect
    }

    Options selectedOption = Options.NextLevel;

    // Use this for initialization
    void Start () {
        LevelController levelController = Camera.main.GetComponent<LevelController>();
        int gems = levelController.getGemStones();
        for (int i = 0; i < gems; i++)
        {
            gemIndicators[i].sprite = gemFull;
        }
        title.text = "Level " + levelController.levelNumber + " complete!";
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
            selectedOption = Options.NextLevel;
            selector.transform.position = new Vector3(selector.transform.position.x, nextLevelButton.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (selectedOption == Options.NextLevel)
            {
                SceneManager.LoadScene("Scene1");
            }
        }
	}
}

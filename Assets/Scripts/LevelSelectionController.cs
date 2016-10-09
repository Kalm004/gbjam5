using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectionController : MonoBehaviour {
    private int selectedLevel = 1;

	// Use this for initialization
	void Start () {
	
	}
	
    public int getSelectedLevel()
    {
        return selectedLevel;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedLevel++;
            if (selectedLevel > GameManager.Instance.gameInfo.maxUnlockedLevel)
            {
                selectedLevel = GameManager.Instance.gameInfo.maxUnlockedLevel;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedLevel--;
            if (selectedLevel < 1)
            {
                selectedLevel = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedLevel += 3;
            if (selectedLevel > GameManager.Instance.gameInfo.maxUnlockedLevel)
            {
                selectedLevel -= 3;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedLevel -= 3;
            if (selectedLevel < 1)
            {
                selectedLevel += 3;
            }
        }
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(Scenes.Level + selectedLevel.ToString());
        }
	}
}

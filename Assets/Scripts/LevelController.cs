using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
    public GameObject gameOverScreen;
    public GameObject finishScreen;
    public GameObject pauseScreen;
    public int levelNumber;
    private int gemStones = 0;
    private int hearts = 3;

    public int getGemStones()
    {
        return gemStones;
    }

    public int getHearts()
    {
        return hearts;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape) && !pauseScreen.activeSelf)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
	}

    public void gemStonePickUp()
    {
        gemStones++;
    }

    public void playerHurt()
    {
        hearts--;
        if (hearts <= 0)
        {
            gameOver();
        }
    }

    public void finishLevel()
    {
        if (!finishScreen.activeSelf)
        {
            GameManager.Instance.saveLevelResult(levelNumber, gemStones);
            finishScreen.SetActive(true);
        }
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}

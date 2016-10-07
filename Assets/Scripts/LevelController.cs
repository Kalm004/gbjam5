using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
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
        SceneManager.LoadScene("Scene1");
    }

    public void gameOver()
    {
        SceneManager.LoadScene("Scene1");
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
    private int gemStones = 0;

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

    public void finishLevel()
    {
        SceneManager.LoadScene("Scene1");
    }
}

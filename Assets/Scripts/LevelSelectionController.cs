using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectionController : MonoBehaviour {
    private int selectedLevel = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(Scenes.Level + selectedLevel.ToString());
        }
	}
}

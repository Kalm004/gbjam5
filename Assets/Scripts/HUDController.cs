using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {
    public GameObject[] emptyGems;
    public GameObject[] fullGems;
    public GameObject[] emptyHearts;
    public GameObject[] fullHearts;
    private LevelController levelController;

    // Use this for initialization
    void Start () {
        levelController = Camera.main.GetComponent<LevelController>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (levelController.getGemStones() > 0)
        {
            emptyGems[0].SetActive(false);
            fullGems[0].SetActive(true);
        }
        if (levelController.getGemStones() > 1)
        {
            emptyGems[1].SetActive(false);
            fullGems[1].SetActive(true);
        }
        if (levelController.getGemStones() > 2)
        {
            emptyGems[2].SetActive(false);
            fullGems[2].SetActive(true);
        }

        if (levelController.getHearts() > 0)
        {
            emptyHearts[0].SetActive(false);
            fullHearts[0].SetActive(true);
        }
        if (levelController.getHearts() > 1)
        {
            emptyHearts[1].SetActive(false);
            fullHearts[1].SetActive(true);
        }
        if (levelController.getHearts() > 2)
        {
            emptyHearts[2].SetActive(false);
            fullHearts[2].SetActive(true);
        }
    }
}

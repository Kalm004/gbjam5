using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelItemController : MonoBehaviour {
    public Image[] gems;
    public Text levelNumberText;
    public GameObject selector;
    public GameObject levelLock;
    public float blinkTime = 0.1f;
    public int levelNumber;
    public Sprite gemFull;
    private bool selected = true;
    private bool locked = false;
    private float timeSinceLastBlink = 0;
    private LevelSelectionController levelSelectionController;

	// Use this for initialization
	void Start () {
        levelSelectionController = transform.parent.GetComponent<LevelSelectionController>();
        locked = GameManager.Instance.getLevelLocked(levelNumber);
        int gems = GameManager.Instance.getLevelGems(levelNumber);
        for (int i = 0; i < gems; i++)
        {
            this.gems[i].sprite = gemFull;
        }
        levelNumberText.text = levelNumber.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (!locked)
        {
            selected = (levelSelectionController.getSelectedLevel() == levelNumber);
            levelLock.SetActive(false);
            if (selected)
            {
                timeSinceLastBlink += Time.deltaTime;
                if (timeSinceLastBlink > blinkTime)
                {
                    timeSinceLastBlink = 0;
                    selector.SetActive(!selector.activeSelf);
                }
            }
            else
            {
                selector.SetActive(false);
            }
        } else
        {
            levelLock.SetActive(true);
            selector.SetActive(false);
            levelNumberText.enabled = false;
        }
	}
}

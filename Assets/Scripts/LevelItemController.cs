using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelItemController : MonoBehaviour {
    public Image[] gems;
    public Text levelNumberText;
    public GameObject selector;
    public float blinkTime = 0.1f;
    private bool selected = true;
    private float timeSinceLastBlink = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (selected)
        {
            timeSinceLastBlink += Time.deltaTime;
            if (timeSinceLastBlink > blinkTime)
            {
                timeSinceLastBlink = 0;
                selector.SetActive(!selector.activeSelf);
            }
        } else
        {
            selector.SetActive(false);
        }
	}
}

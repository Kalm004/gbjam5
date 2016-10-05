using UnityEngine;
using System.Collections;

public class UpArrowsController : MonoBehaviour {
    public GameObject arrow1;
    public GameObject arrow2;
    private float elapsedTime = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 0.1f)
        {
            arrow1.SetActive(!arrow1.activeSelf);
            arrow2.SetActive(!arrow2.activeSelf);
            elapsedTime = 0;
        }
    }
}

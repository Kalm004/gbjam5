using UnityEngine;
using System.Collections;

public class StoneSpawnerController : MonoBehaviour {
    public GameObject rockPrefab;
    public GameObject exclamation;
    public float timeToLaunch = 1f;
    private bool generatingStone = false;
    private float elapsedTime = 0;
    private float rockHeight;

    // Use this for initialization
    void Start () {
        rockHeight = rockPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
	}
	
	// Update is called once per frame
	void Update () {
        stayUpOnScreen();
        if (generatingStone)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= timeToLaunch)
            {
                generatingStone = false;
                elapsedTime = 0;
                exclamation.SetActive(false);
                GameObject rock = GameObject.Instantiate(rockPrefab);
                rock.transform.position = transform.position;
            }
        }
    }

    public void generateStone()
    {
        if (!generatingStone)
        {
            generatingStone = true;
            exclamation.SetActive(true);
        }

    }

    private void stayUpOnScreen()
    {
        Vector3 wolrdPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        transform.position = new Vector3(transform.position.x, wolrdPos.y + rockHeight, transform.position.z);
    }
}

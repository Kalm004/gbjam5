using UnityEngine;
using System.Collections;

public class StoneSpawnerController : MonoBehaviour {
    public GameObject rockPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        stayUpOnScreen();
    }

    public void generateStone()
    {
        GameObject rock = GameObject.Instantiate(rockPrefab);
        rock.transform.position = transform.position;
    }

    private void stayUpOnScreen()
    {

    }
}

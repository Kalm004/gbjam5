using UnityEngine;
using System.Collections;

public class ExclamationController : MonoBehaviour {
    public float showingTime = 0.1f;
    private float elapsedTime = 0;
    private SpriteRenderer r;
    
    // Use this for initialization
    void Start () {
        r = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= showingTime)
        {
            r.enabled = !r.enabled;
            elapsedTime = 0;
        }
    }
}

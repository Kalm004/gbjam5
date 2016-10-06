using UnityEngine;
using System.Collections;

public class DestroyOnNumberOfChilds : MonoBehaviour {
    public int childNum = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.childCount <= childNum)
        {
            Destroy(gameObject);
        }
	}
}
using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Rigidbody2D playerRb;
    private bool moving = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!moving)
        {
            if (playerRb.velocity.y == 0 && Camera.main.WorldToScreenPoint(playerRb.transform.position).y > 100)
            {
                moving = true;
            }
        } else
        {
            transform.Translate(0, 5 * Time.fixedDeltaTime, 0);
            if (Camera.main.WorldToScreenPoint(playerRb.transform.position).y < 40)
            {
                moving = false;
            }
        }
	}
}

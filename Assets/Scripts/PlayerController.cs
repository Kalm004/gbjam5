using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject upArrows;
    private Rigidbody2D rb;
    private float stoppedTime = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FixedUpdate()
    {
        float velocity = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity = -5;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity = 5;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
        rb.velocity = new Vector2(velocity, rb.velocity.y);
        Physics2D.IgnoreLayerCollision(gameObject.layer, platformPrefab.layer, rb.velocity.y > 0);

        if (rb.velocity.magnitude == 0)
        {
            stoppedTime += Time.fixedDeltaTime;
            if (stoppedTime > 1)
            {
                Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2));
                upArrows.transform.position = new Vector3(0, point.y);
                upArrows.SetActive(true);
            }
        } else
        {
            stoppedTime = 0;
            upArrows.SetActive(false);
        }
    }
}

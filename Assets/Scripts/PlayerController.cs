using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject upArrows;
    private Rigidbody2D rb;
    private float stoppedTime = 0;
    private float timeToRestart = 0;

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
        if (Input.GetKey(KeyCode.UpArrow) && rb.velocity.y == 0)
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
                upArrows.transform.position = new Vector3(upArrows.transform.position.x, point.y);
                upArrows.SetActive(true);
            }
        } else
        {
            stoppedTime = 0;
            upArrows.SetActive(false);
        }

        if (Camera.main.WorldToScreenPoint(new Vector3(0, transform.position.y + GetComponent<SpriteRenderer>().sprite.bounds.size.y)).y < 0)
        {
            if (timeToRestart == 0)
            {
                timeToRestart = Time.time + 1;
            }
        }
        if (timeToRestart != 0 && Time.time > timeToRestart)
        {
            SceneManager.LoadScene("Scene1");
        }
    }
}

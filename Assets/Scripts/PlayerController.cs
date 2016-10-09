using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject upArrows;
    public float blinkingTime = 1f;
    public float jumpMaxTime = 0.2f;
    public float jumpForce = 25f;
    public float lateralAcceleratingTime = 0.5f;
    public float lateralMaxVelocity = 3f;
    public float jumpThresshold = 0.2f;
    public AudioSource death;
    public AudioSource hit;
    public AudioSource jump;
    public AudioSource pickUp;
    private Rigidbody2D rb;
    private float stoppedTime = 0;
    private float timeToRestart = 0;
    private bool beingHitting = false;
    private float blinkingLimitTime = 0;
    private float currentBlink = 0;
    private SpriteRenderer spriteRenderer;
    private LevelController levelController;
    private float pressedTimeUpKey = 0f;
    private float pressedTimeLeftArrow = 0f;
    private float pressedTimeRightArrow = 0f;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelController = Camera.main.GetComponent<LevelController>();
        animator = GetComponent<Animator>();
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
            pressedTimeLeftArrow += Time.fixedDeltaTime;
            if (pressedTimeLeftArrow < lateralAcceleratingTime)
            {
                velocity = - pressedTimeLeftArrow / lateralAcceleratingTime * lateralMaxVelocity;
            }
            else
            {
                velocity = - lateralMaxVelocity;
            }
        } else
        {
            pressedTimeLeftArrow = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pressedTimeRightArrow += Time.fixedDeltaTime;
            if (pressedTimeRightArrow < lateralAcceleratingTime)
            {
                velocity = pressedTimeRightArrow / lateralAcceleratingTime * lateralMaxVelocity;
            }
            else
            {
                velocity = lateralMaxVelocity;
            }
        } else
        {
            pressedTimeRightArrow = 0;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (pressedTimeUpKey == 0 && rb.velocity.y == 0)
            {
                jump.Play();
            }
            if ((pressedTimeUpKey == 0 && rb.velocity.y == 0) || (pressedTimeUpKey > 0 && pressedTimeUpKey < jumpMaxTime))
            {
                pressedTimeUpKey += Time.fixedDeltaTime;
                rb.AddForce(Vector2.up * jumpForce);
            }
        } else
        {
            pressedTimeUpKey = 0;
        }
        rb.velocity = new Vector2(velocity, rb.velocity.y);
        if (velocity > 0)
        {
            animator.SetBool("Moving", true);
            animator.SetInteger("Direction", 1);
        }
        else if (velocity < 0)
        {
            animator.SetBool("Moving", true);
            animator.SetInteger("Direction", -1);
        } else
        {
            animator.SetBool("Moving", false);
        }

        if (rb.velocity.y > jumpThresshold)
        {
            animator.SetBool("Jumping", true);
            animator.SetInteger("JumpDirection", 1);
        } else if (rb.velocity.y < -jumpThresshold)
        {
            animator.SetBool("Jumping", true);
            animator.SetInteger("JumpDirection", -1);
        } else if (rb.velocity.y != 0)
        {
            animator.SetBool("Jumping", true);
            animator.SetInteger("JumpDirection", 0);
        } else
        {
            animator.SetBool("Jumping", false);
        }

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
                death.Play();
            }
        }
        if (timeToRestart != 0 && Time.time > timeToRestart)
        {
            levelController.gameOver();
        }
        if (blinkingLimitTime != 0)
        {
            currentBlink += Time.fixedDeltaTime;
            if (currentBlink >= 0.1f)
            {
                currentBlink = 0;
                spriteRenderer.enabled = !spriteRenderer.enabled;
            }
            if (Time.time >= blinkingLimitTime)
            {
                blinkingLimitTime = 0;
                beingHitting = false;
                spriteRenderer.enabled = true;
            }
        }
    }

    public void hitByRock()
    {
        if (!beingHitting)
        {
            beingHitting = true;
            blinkingLimitTime = Time.time + blinkingTime;
            hit.Play();
            levelController.playerHurt();
        }
    }

    public void gemStonePickUp()
    {
        pickUp.Play();
    }
}

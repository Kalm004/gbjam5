using UnityEngine;
using System.Collections;

public class DestructiblePlatformController : MonoBehaviour
{
    public Sprite destroyedSprite;
    public float timeToDestroy = 1f;
    private Rigidbody2D player;
    private bool beingDestroyed = false;
    private float destroyOnTime;
    private bool destroyed = false;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(GameTags.Player).GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!destroyed && beingDestroyed && Time.time > destroyOnTime)
        {
            destroyed = true;
            hide();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!beingDestroyed)
        {
            if (collision.gameObject.tag == GameTags.Player && player.velocity.y == 0)
            {
                beingDestroyed = true;
                spriteRenderer.sprite = destroyedSprite;
                destroyOnTime = Time.time + timeToDestroy;
            }
        }
    }

    private void hide()
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
    }
}

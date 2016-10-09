using UnityEngine;
using System.Collections;

public class GemstoneController : MonoBehaviour
{
    public float movementTime = 0.1f;
    public float speed = 1;
    private float currentElapsedTime = 0;
    private LevelController levelCtrl;
    private PlayerController playerCtrl;

    // Use this for initialization
    void Start()
    {
        levelCtrl = Camera.main.GetComponent<LevelController>();
        playerCtrl = GameObject.FindGameObjectWithTag(GameTags.Player).GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentElapsedTime += Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == GameTags.PlayerBig)
        {
            levelCtrl.gemStonePickUp();
            playerCtrl.gemStonePickUp();
            Destroy(gameObject);
        }
    }
}

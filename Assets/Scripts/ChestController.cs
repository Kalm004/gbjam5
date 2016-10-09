using UnityEngine;
using System.Collections;

public class ChestController : MonoBehaviour
{
    private LevelController levelCtrl;
    private Rigidbody2D player;

    // Use this for initialization
    void Start()
    {
        levelCtrl = Camera.main.GetComponent<LevelController>();
        player = GameObject.FindGameObjectWithTag(GameTags.Player).GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == GameTags.PlayerBig && player.velocity.y == 0)
        {
            levelCtrl.finishLevel();
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == GameTags.PlayerBig && player.velocity.y == 0)
        {
            levelCtrl.finishLevel();
        }
    }
}

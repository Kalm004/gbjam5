using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour
{
    private PlayerController playerController;

    // Use this for initialization
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag(GameTags.Player).GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == GameTags.PlayerHitBox)
        {
            playerController.hitByRock();
            Destroy(gameObject);
        }
    }
}

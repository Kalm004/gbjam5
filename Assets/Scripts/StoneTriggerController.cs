using UnityEngine;
using System.Collections;

public class StoneTriggerController : MonoBehaviour
{
    public StoneSpawnerController[] spawners;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == GameTags.PlayerBig)
        {
            foreach (StoneSpawnerController spawnerCtrl in spawners)
            {
                spawnerCtrl.generateStone();
            }
        }
    }
}

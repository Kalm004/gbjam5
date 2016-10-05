using UnityEngine;
using System.Collections;

public class ChestController : MonoBehaviour {
    private LevelController levelCtrl;

    // Use this for initialization
    void Start () {
        levelCtrl = Camera.main.GetComponent<LevelController>();
    }

    // Update is called once per frame
    void Update() {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == GameTags.PlayerBig)
        {
            levelCtrl.finishLevel();
        }
    }
}

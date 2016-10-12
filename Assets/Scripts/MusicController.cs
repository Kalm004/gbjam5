using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

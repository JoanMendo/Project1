using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonMenu : MonoBehaviour
{
    private Rigidbody2D rb;
    private static SingletonMenu instance;
    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

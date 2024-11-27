using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonMenu : MonoBehaviour
{
    private void Start()
    {
            DontDestroyOnLoad(this.gameObject);
        
    }
}

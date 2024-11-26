using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonScript : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject PauseButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPresed()
    {
        Canvas.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void ButtonUnPressed()
    {
        Canvas.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }
}

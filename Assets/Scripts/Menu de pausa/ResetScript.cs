using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject PauseButton;

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

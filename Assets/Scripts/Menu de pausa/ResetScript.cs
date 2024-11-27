using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject PauseButton;

    public void ButtonPresed()
    {
        SceneManager.LoadScene("EscenaInicial");
    }

    public void ButtonPressed()
    {
        Canvas.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }
}

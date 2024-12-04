using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonScript : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject PauseButton;
    public GameObject player;
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow); // Change FullScreenMode as needed
    }

    public void ResetButtonPresed()
    {
        PauseButton.SetActive(false);
        player.SetActive(false);
        //Destroy(player);
        SceneManager.LoadScene("EscenaInicial");
    }

    public void PauseButtonPressed()
    {
        Canvas.GetComponent<Canvas>().enabled = true;
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void PauseButtonUnPressed()
    {
        Canvas.GetComponent<Canvas>().enabled = false;
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

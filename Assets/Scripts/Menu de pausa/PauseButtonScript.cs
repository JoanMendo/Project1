using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonScript : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject PauseButton;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetButtonPresed()
    {
        PauseButton.SetActive(false);
        player.SetActive(false);
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

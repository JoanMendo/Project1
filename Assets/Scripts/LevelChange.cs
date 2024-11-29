using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public GameObject player;
    public Canvas playerInterface;
    public int level;
    public int exit;
    public int Protanopia = 0;
    public int Deuteranopia = 0;
    public int Tritanopia = 0;


    public void Start()
    {
        player = GameObject.FindWithTag("Personaje");


        if (level >= 1)
        {
            playerInterface = GameObject.FindWithTag("Interface").GetComponent<Canvas>();
            UpdateInterface();
        }

    }

    public void UpdateInterface()
    {
        playerInterface.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Nivel " + level;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            ApiRequest.instance.times[level] = Time.time;
            ApiRequest.instance.exits[level] = exit;
            if (exit == 0)
            {
                checkDaltonism();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            // Do not send right now.
            //ApiRequest.instance.StartCoroutine(ApiRequest.instance.SendPostRequest());
        }

    }

    public void checkDaltonism()
    {
        ApiRequest apiComponent = GameObject.Find("/Api").GetComponent<ApiRequest>();

        apiComponent.totalProtanopia += Protanopia;
        apiComponent.totalDeuteranopia += Deuteranopia;
        apiComponent.totalTritanopia += Tritanopia;

    }
}

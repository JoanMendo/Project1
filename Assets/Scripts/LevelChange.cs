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

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Personaje");
        playerInterface = GameObject.FindGameObjectWithTag("Interface").GetComponent<Canvas>();

        UpdateInterface();
    }

    public void UpdateInterface()
    {
        Debug.Log("Eyo");
        playerInterface.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Nivel " + level;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            ApiRequest.instance.times[level] = Time.time;
            ApiRequest.instance.exits[level] = exit;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            ApiRequest.instance.StartCoroutine(ApiRequest.instance.SendPostRequest());
        }
        


    }
}

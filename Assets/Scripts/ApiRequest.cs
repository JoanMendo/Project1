using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ApiRequest : MonoBehaviour
{
    public static ApiRequest instance;
    public int age;
    public int[] exits = new int[12];
    public float[] times = new float[12];
    public int[] deaths = new int[12];


    private void Awake()
    {
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

    /*
    void Start()
    {
        // Call the method to send the request
        StartCoroutine(SendPostRequest());
    }
    */

    public IEnumerator SendPostRequest()
    {
        // Crear datos aleatorios
        int gender = Random.Range(0, 3); // Genero aleatorio entre 0, 1, 2

        // Debug de datos
        Debug.Log("Data: ");
        Debug.Log($"Gender: {gender}, Age: {age}");
        Debug.Log($"Exits: {string.Join(", ", exits)}");
        Debug.Log($"Times: {string.Join(", ", times)}");
        Debug.Log($"Deaths: {string.Join(", ", deaths)}");

        // Construir la URL y parámetros
        string url = "http://127.0.0.1:5000/api/v1/results";

        // Codificar los datos como parámetros
        string exitsStr = string.Join(",", exits);
        string timesStr = string.Join(",", times);
        string deathsStr = string.Join(",", deaths);

        string queryString = $"?gender={gender}&age={age}&exits={UnityWebRequest.EscapeURL(exitsStr)}&times={UnityWebRequest.EscapeURL(timesStr)}&deaths={UnityWebRequest.EscapeURL(deathsStr)}";

        // Combinar la URL base con los parámetros
        string fullUrl = url + queryString;

        Debug.Log("Request URL: " + fullUrl);

        // Enviar la solicitud GET (o POST si es necesario con un body vacío)
        using (UnityWebRequest www = UnityWebRequest.Post(fullUrl, "")) // También puedes usar UnityWebRequest.Post con URL vacía
        {
            // Esperar la respuesta
            yield return www.SendWebRequest();

            // Verificar errores
            if (www.result == UnityWebRequest.Result.Success)
            {
                // Respuesta exitosa
                Debug.Log("Response: " + www.downloadHandler.text);
            }
            else
            {
                // Manejar errores
                Debug.LogError("Error: " + www.error);
            }
        }
    }

}

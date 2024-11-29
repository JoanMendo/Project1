using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ApiRequest : MonoBehaviour
{
    public static ApiRequest instance;
    public int gender;
    public int age;
    public int[] exits = new int[12];
    public float[] times = new float[12];
    public int[] deaths = new int[12];

    public int totalProtanopia = 0;
    public int totalDeuteranopia = 0;
    public int totalTritanopia = 0;


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

   

    public IEnumerator SendPostRequest()
    {


        // Debug de datos
        Debug.Log("Data: ");
        Debug.Log($"Gender: {gender}, Age: {age}");
        Debug.Log($"Exits: {string.Join(", ", exits)}");
        Debug.Log($"Times: {string.Join(", ", times)}");
        Debug.Log($"Deaths: {string.Join(", ", deaths)}");


        string url = "http://127.0.0.1:5000/api/v1/results";

        string exitsStr = string.Join(",", exits);
        string timesStr = string.Join(",", times);
        string deathsStr = string.Join(",", deaths);

        string queryString = $"?gender={gender}&age={age}&exits={UnityWebRequest.EscapeURL(exitsStr)}&times={UnityWebRequest.EscapeURL(timesStr)}&deaths={UnityWebRequest.EscapeURL(deathsStr)}";

        // Combinar la URL base con los par�metros
        string fullUrl = url + queryString;

        Debug.Log("Request URL: " + fullUrl);


        using (UnityWebRequest www = UnityWebRequest.PostWwwForm(fullUrl, "")) 
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

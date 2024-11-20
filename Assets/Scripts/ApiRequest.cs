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

    void Start()
    {
        // Call the method to send the request
        StartCoroutine(SendPostRequest());
    }

    public IEnumerator SendPostRequest()
    {
        // Create random data
        int gender = Random.Range(0, 3); // Random gender between 0, 1, 2

        // Print the data to console for debugging
        Debug.Log("Data: ");
        Debug.Log($"Gender: {gender}, Age: {age}");
        Debug.Log($"Exits: {string.Join(", ", exits)}");
        Debug.Log($"Times: {string.Join(", ", times)}");
        Debug.Log($"Deaths: {string.Join(", ", deaths)}");

        // Construct the URL and parameters for the POST request
        string url = "http://127.0.0.1:5000/api/v1/results";
        string exitsStr = string.Join(",", exits);
        string timesStr = string.Join(",", times);
        string deathsStr = string.Join(",", deaths);

        // Create a WWWForm to send the parameters
        WWWForm form = new WWWForm();
        form.AddField("gender", gender.ToString());
        form.AddField("age", age.ToString());
        form.AddField("exits", exitsStr);
        form.AddField("times", timesStr);
        form.AddField("deaths", deathsStr);

        // Send the POST request
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            // Wait until the request is completed
            yield return www.SendWebRequest();

            // Check for errors
            if (www.result == UnityWebRequest.Result.Success)
            {
                // If the request was successful, print the response
                Debug.Log("Response: " + www.downloadHandler.text);
            }
            else
            {
                // If there was an error, print the error message
                Debug.LogError("Error: " + www.error);
            }
        }
    }
}

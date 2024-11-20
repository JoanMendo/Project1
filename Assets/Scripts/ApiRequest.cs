using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ApiRequest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Call the method to send the request
        StartCoroutine(SendPostRequest());
    }

    IEnumerator SendPostRequest()
    {
        // Create random data
        int gender = Random.Range(0, 3); // Random gender between 0, 1, 2
        int age = Random.Range(1, 100);  // Random age between 1 and 99
        int[] exits = new int[4];
        float[] times = new float[] { 10.5f, 80.12f, 54.44f, 76.10f };
        int[] deaths = new int[4];

        // Populate exits and deaths with random values
        for (int i = 0; i < 4; i++)
        {
            exits[i] = Random.Range(1, 3); // Random exits (1 or 2)
            deaths[i] = Random.Range(0, 6); // Random deaths (0 to 5)
        }

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

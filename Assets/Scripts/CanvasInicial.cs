using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CanvasInicial : MonoBehaviour
{

    private string Name;
    private bool Age;
    public GameObject PlayButton;
    public GameObject Inputs;
    public GameObject NameInput;
    public GameObject AgeInput;
    public GameObject Player;
    public GameObject light2D;
    public GameObject lightSalida;
    public GameObject instrucciones;

    private bool validName;
    private bool validAge;

    public void StartButton()
    {
        Destroy(PlayButton);
        Inputs.SetActive(true);
    }

    public void CheckInputs()
    {

        Name = NameInput.GetComponent<TMPro.TMP_InputField>().text;
        Age = int.TryParse(AgeInput.GetComponent<TMPro.TMP_InputField>().text, out int parsedAge);

        if (Name.Length > 1)
        {
            validName = true;
        }
        else
        {
            NameInput.GetComponent<TMPro.TMP_InputField>().text = "Invalid Name";
        }

        if(Age && parsedAge > 0 && parsedAge < 100)
        {
            validAge = true;
        }
        else
        {
            AgeInput.GetComponent<TMPro.TMP_InputField>().text = "Invalid Age";
        }
        if (validAge && validName)
        {
            ApiRequest.instance.age = parsedAge;
            ApiRequest.instance.name = Name;
            light2D.SetActive(false);
            Inputs.SetActive(false);
            StartCoroutine(SetPlayerActive());
        }

    }

    public IEnumerator SetPlayerActive()
    {

        yield return new WaitForSeconds(1f);
        Player.SetActive(true);
        lightSalida.SetActive(true);
        instrucciones.SetActive(true);
    }
    


}

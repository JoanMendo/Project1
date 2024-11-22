using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CanvasInicial : MonoBehaviour
{

    private int Gender;
    private bool Age;
    public GameObject PlayButton;
    public GameObject Inputs;
    public GameObject GenderInput;
    public GameObject AgeInput;
    public GameObject Player;
    public GameObject light2D;
    public GameObject lightSalida;
    public GameObject lightInstrucciones;
    public GameObject instrucciones;
    private bool validAge;

    public void StartButton()
    {
        Destroy(PlayButton);
        Inputs.SetActive(true);
    }

    public void CheckInputs()
    {

        //Define el gender que es un input donde tienes 3 opciones a seleccionar
        Gender = GenderInput.GetComponent<TMPro.TMP_Dropdown>().value;
        
        Age = int.TryParse(AgeInput.GetComponent<TMPro.TMP_InputField>().text, out int parsedAge);

        

        if(Age && parsedAge > 0 && parsedAge < 100)
        {
            validAge = true;
        }
        else
        {
            AgeInput.GetComponent<TMPro.TMP_InputField>().text = "Invalid Age";
        }
        if (validAge)
        {
            ApiRequest.instance.age = parsedAge;
            ApiRequest.instance.gender = Gender;
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
        lightInstrucciones.SetActive(true);
        instrucciones.SetActive(true);
    }
    


}

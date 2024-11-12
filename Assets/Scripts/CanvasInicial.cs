using System.Collections;
using System.Collections.Generic;
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
    public Light2D light2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        Destroy(PlayButton);
        Inputs.SetActive(true);
    }

    public void CheckInputs()
    {

        Name = NameInput.GetComponent<TMPro.TMP_InputField>().text;
         Age = int.TryParse(AgeInput.GetComponent<TMPro.TMP_InputField>().text, out int parsedAge);

        if (Name != "" && parsedAge > 0)
        {

            light2D.pointLightOuterRadius = 0;
            Inputs.SetActive(false);
            StartCoroutine(SetPlayerActive());
        }

    }

    public IEnumerator SetPlayerActive()
    {

        yield return new WaitForSeconds(1.5f);
        Player.SetActive(true);
    }
    


}

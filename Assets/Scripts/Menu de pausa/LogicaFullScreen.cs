using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicaFullScreen : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn= false;
        }
        RevisarResolucion();
    }
    public void RevisarResolucion ()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0; i < resolutions.Length; i++)
        { 
            string opcion = resolutions[i].width + "x" + resolutions[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolucionActual = 1;
            } 
        }
        resolutionDropDown.AddOptions(opciones);
        resolutionDropDown.value = resolucionActual;
        resolutionDropDown.RefreshShownValue();
        resolutionDropDown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    }

    public void CambiarResolucion(int indiceResolucion)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolutionDropDown.value);
        Resolution resolution = resolutions[indiceResolucion];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void ActivarFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}

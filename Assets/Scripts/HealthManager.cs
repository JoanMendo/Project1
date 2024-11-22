using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public Image healthBar;

    public void ChangeHealthBar(float currentHealth)
    {

        healthBar.fillAmount =  currentHealth / 0.5f;

    }

}

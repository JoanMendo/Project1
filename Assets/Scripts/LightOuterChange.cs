using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightOuterChange : MonoBehaviour
{
    public float minOuter;
    public float maxOuter;
    public float speed;
    private bool isIncreasing = true;
    private Light2D light2D;
    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isIncreasing)
        {
            light2D.pointLightOuterRadius += speed * Time.deltaTime;
        }
        else
        {
            light2D.pointLightOuterRadius -= speed * Time.deltaTime;
        }
        if (light2D.pointLightOuterRadius >= maxOuter)
        {
            isIncreasing = false;
        }
        if (light2D.pointLightOuterRadius <= minOuter)
        {
            isIncreasing = true;
        }
    }
}

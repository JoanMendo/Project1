using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharact : MonoBehaviour
{
    public GameObject character;
    void Start()
    {
        character = GameObject.Find("Personaje");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = character.transform.position;
    }
}

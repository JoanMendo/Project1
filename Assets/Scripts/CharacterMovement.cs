using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 5f;
    public GameObject respawnPosition;
    private Vector2 movement;
    private float inputX;
    private float inputY;
    private static CharacterMovement instance;

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

        rb = GetComponent<Rigidbody2D>();

        


    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(inputX, inputY).normalized;
        rb.velocity = movement * speed;


    }


    public void Die()
    {

        StartCoroutine(respawnFreeze());
        transform.position = respawnPosition.transform.position;


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            //Die();
        }
    }

    public IEnumerator respawnFreeze()
    {

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }





    public void OnSceneLoaded()
    {
        respawnPosition = GameObject.FindGameObjectWithTag("Respawn");
    }

}

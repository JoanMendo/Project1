using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public GameObject respawnPosition;
    private Vector2 movement;
    private float inputX;
    private float inputY;
    //private GameObject originalTrail;
    public string trailName;
   // private GameObject temporalTrail;
    //private GameObject temporalBackTrail;
    private Queue queue;
    private Vector2 lastOffset;

    void Start()
    {
        queue = new Queue();
        rb = GetComponent<Rigidbody2D>();
       /* originalTrail = GameObject.Find(trailName);
        originalTrail.transform.position = transform.position;
        CreateTrail();*/
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(inputX, inputY).normalized;
        rb.velocity = movement * speed;
        Vector2 offset = movement * 0.2f;
        if (offset != Vector2.zero)
        {
            lastOffset = offset;
        }
        

       /* temporalTrail.transform.position = transform.position;
        temporalBackTrail.transform.position = (Vector2)transform.position + lastOffset; */
    }

    /*
    public void CreateTrail()
    {
        if (queue.Count >= 10)
        {
            GameObject trail = (GameObject)queue.Dequeue();
            GameObject backTrail = (GameObject)queue.Dequeue();
            Destroy(trail);
            Destroy(backTrail);

        }
        
        temporalTrail = Instantiate(originalTrail);
        temporalTrail.name = "Mondongo";
        originalTrail = temporalTrail;
        temporalBackTrail = Instantiate(originalTrail);
        temporalBackTrail.name = "Mondongo";
        temporalBackTrail.GetComponent<TrailRenderer>().startColor = Color.black;
        temporalBackTrail.GetComponent<TrailRenderer>().endColor = Color.black;
        temporalBackTrail.GetComponent<TrailRenderer>().widthMultiplier *= 1.15f;
        temporalBackTrail.GetComponent<TrailRenderer>().sortingOrder = 4;
        temporalTrail.GetComponent<TrailRenderer>().emitting = true;
        temporalBackTrail.GetComponent<TrailRenderer>().emitting = true;
        queue.Enqueue(temporalTrail);
        queue.Enqueue(temporalBackTrail);

        
    } */

    public void Die()
    {
        /*CreateTrail();
        StartCoroutine(respawnFreeze());
        transform.position = respawnPosition.transform.position;*/

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Die();
        }
    }

    public IEnumerator respawnFreeze()
    {

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;


public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float life = 2.5f;
    public float speed = 5f;
    public GameObject respawnPosition;

    private float lifeTime = 0f;
    private Vector2 movement;
    private float inputX;
    private float inputY;
    private static CharacterMovement instance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
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
        transform.position = respawnPosition.transform.position;
        StartCoroutine(respawnFreeze());
        
    }

    

    public IEnumerator respawnFreeze()
    {

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        Debug.Log("Scene loaded");
        respawnPosition = GameObject.FindGameObjectWithTag("Respawn");
        Die();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        lifeTime += Time.deltaTime;
        Debug.Log(lifeTime);

        if (lifeTime >= life)
        {
            lifeTime = 0;
            ApiRequest.instance.deaths[SceneManager.GetActiveScene().buildIndex] += 1;
            Die();
        }
    }

}

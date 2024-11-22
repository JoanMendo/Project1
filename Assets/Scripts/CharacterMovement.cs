using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;


public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public GameObject respawnPosition;
    public HealthManager healthManager;

    private float lifeTime = 0.5f;
    private Vector2 movement;
    private float inputX;
    private float inputY;
    private static CharacterMovement instance;

    private void Awake()
    {
        healthManager = GameObject.FindGameObjectWithTag("Interface").GetComponent<HealthManager>();
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

        healthManager.ChangeHealthBar(lifeTime);
        
        //Que se le regenere la vida
        if (lifeTime < 0.5)
        {
            lifeTime += Time.deltaTime/4;
        }
        




    }
    public void Die()
    {
        transform.position = respawnPosition.transform.position;
        Debug.Log("You died");
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
        
        lifeTime -= Time.deltaTime;
        Debug.Log(lifeTime);

        if (lifeTime <= 0)
        {
            lifeTime = 0.5f;
            ApiRequest.instance.deaths[SceneManager.GetActiveScene().buildIndex] += 1;
            Die();
        }
    }

}

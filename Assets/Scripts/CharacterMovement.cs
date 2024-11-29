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
    public AudioClip deathSound;
    public AudioClip levelChangeSound;
    [SerializeField] AudioSource SFXSource;

    [SerializeField] private ParticleSystem deathEffect;   
    
    private float lifeTime = 0.5f;
    private Vector2 movement;
    private bool isDying = false;
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
        if(isDying) return;
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(inputX, inputY).normalized;
        rb.velocity = movement * speed;

        healthManager.ChangeHealthBar(lifeTime);

    }
    public IEnumerator Die()
    {
        isDying = true;
        SFXSource.PlayOneShot(deathSound);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        healthManager.ChangeHealthBar(0);
        rb.velocity = Vector2.zero;

        deathEffect.Play();
        
        yield return new WaitForSeconds(0.5f);
        
        isDying = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        transform.position = respawnPosition.transform.position;

    }

    

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        lifeTime = 0.5f;
        healthManager = GameObject.FindGameObjectWithTag("Interface").GetComponent<HealthManager>();
        respawnPosition = GameObject.FindGameObjectWithTag("Respawn");
        transform.position = respawnPosition.transform.position;
        GetComponentInChildren<Light2D>().pointLightOuterRadius = 0;
        SFXSource.PlayOneShot(levelChangeSound);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain" && !isDying)
        {
            lifeTime -= Time.deltaTime;

            lifeTime -= Time.deltaTime;

            if (lifeTime <= 0)
            {
                lifeTime = 0.5f;
                ApiRequest.instance.deaths[SceneManager.GetActiveScene().buildIndex] += 1;
                StartCoroutine(Die());
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    public GameObject Bullet;
    public GameManager myGameManager;
    public AudioManager myAudioManager;

    public Transform Checker;
    public float CheckerRadius;
    public bool isGrounded;
    public LayerMask GroundLayer;
    // Start is called before the first frame update
    
    void Awake()
    {
        myAudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
        myGameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            myAudioManager.PlaySFX(myAudioManager.jump);
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, playerJumpForce);
        }
        isGrounded = Physics2D.OverlapCircle(Checker.position, CheckerRadius, GroundLayer);
        myrigidbody2D.velocity = new Vector2(playerSpeed, myrigidbody2D.velocity.y);
        if(Input.GetKeyDown(KeyCode.E))
        {
            myAudioManager.PlaySFX(myAudioManager.shot);
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

    IEnumerator WalkCoRoutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if(index == mySprites.Length)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRoutine());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ItemGood"))
        {
            myAudioManager.PlaySFX(myAudioManager.coin);
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }
        else if(collision.CompareTag("ItemBad"))
        {
            Destroy(collision.gameObject);
            myAudioManager.PlaySFX(myAudioManager.death);
            PlayerDeath();
        }
        else if(collision.CompareTag("Deathzone"))
        {   
            myAudioManager.PlaySFX(myAudioManager.death);
            PlayerDeath();
        }
    }
    
    void PlayerDeath()
    {
        SceneManager.LoadScene("SampleScene");
    }
}



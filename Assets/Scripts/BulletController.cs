using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D myrigidbody2D;
    public float bulletSpeed = 10f;
    public GameManager myGameManager; // Fixed the variable declaration

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        myGameManager = FindObjectOfType<GameManager>(); // Fixed the class name
    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody2D.velocity = new Vector2(bulletSpeed, myrigidbody2D.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood")) // Fixed the method name
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("ItemBad")) // Fixed the method name
        {
            myGameManager.AddScore();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Background")){
            Destroy(collision.gameObject);
        }
    }
}

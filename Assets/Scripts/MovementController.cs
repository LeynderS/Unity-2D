using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    public Sprite[] mySprites;
    private int index = 0;

    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(MovementRoutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator MovementRoutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if(index == mySprites.Length)
        {
            index = 0;
        }
        StartCoroutine(MovementRoutine());
    }
}

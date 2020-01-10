using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleCircleCode : MonoBehaviour
{

    Rigidbody2D rigidbody;
    public float speed;

    GameManager gameManager;
    GameObject gameManagerObject;

    bool isCollided = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gameManagerObject = GameObject.FindGameObjectWithTag("gameManagerTag");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    
    void FixedUpdate()
    {
        if(isCollided==false)
        {
            
            rigidbody.MovePosition(rigidbody.position + Vector2.up * speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "rotatingCircleTag")
        {
            transform.SetParent(collision.transform);
            isCollided = true;
        }

        if(collision.tag=="littleCircleTag")
        {
            gameManager.gameOver();
        }
    }
}

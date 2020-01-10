using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircle : MonoBehaviour
{
    public GameObject littleCircle;
    GameObject gamemanager;

    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("gameManagerTag");
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            createLittleCircle();
            
        }
    }

    void createLittleCircle()
    {
        Instantiate(littleCircle, transform.position,transform.rotation);
        gamemanager.GetComponent<GameManager>().changeMainCircleText();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    GameObject rotatingCircle;
    GameObject mainCircle;

    public Animator animator;
    public Text rotatingChamberText;

    public Text firstCircleText, secondCircleText, thirdCircleText;
    public int numberOfRemainingCircles;

    bool isGameOver = false;




    void Start()
    {
        PlayerPrefs.SetInt("save", int.Parse(SceneManager.GetActiveScene().name));


        rotatingCircle = GameObject.FindGameObjectWithTag("rotatingCircleTag");
        mainCircle = GameObject.FindGameObjectWithTag("mainCircleTag");

        rotatingChamberText.text = SceneManager.GetActiveScene().name;

        if (numberOfRemainingCircles < 2) {
            firstCircleText.text = "" + numberOfRemainingCircles;
        } else if (numberOfRemainingCircles < 3)
        {
            firstCircleText.text = "" + numberOfRemainingCircles;
            secondCircleText.text = "" + (numberOfRemainingCircles - 1);
        }
        else
        {
            firstCircleText.text = "" + numberOfRemainingCircles;
            secondCircleText.text = "" + (numberOfRemainingCircles - 1);
            thirdCircleText.text = "" + (numberOfRemainingCircles - 2);
        }
    }


    void Update()
    {
        if (numberOfRemainingCircles < 1 && isGameOver==false)
        {
            StartCoroutine(newLevel());
        }
    }

    public void gameOver()
    {
             isGameOver = true;
            StartCoroutine(gameOverEnumerator());
       
        
    }

    IEnumerator gameOverEnumerator()
    {
            rotatingCircle.GetComponent<Rotate>().enabled = false;
            mainCircle.GetComponent<MainCircle>().enabled = false;
            animator.SetTrigger("gameOver");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("MainMenu");
    }

    public void changeMainCircleText()
    {
        numberOfRemainingCircles -= 1;

        if (numberOfRemainingCircles < 2)
        {
            firstCircleText.text = "" + numberOfRemainingCircles;
            secondCircleText.text = "";
            thirdCircleText.text = "";
            
        }
        else if (numberOfRemainingCircles < 3)
        {
            firstCircleText.text = "" + numberOfRemainingCircles;
            secondCircleText.text = "" + (numberOfRemainingCircles - 1);
            thirdCircleText.text = "";
        }
        else
        {
            firstCircleText.text = "" + numberOfRemainingCircles;
            secondCircleText.text = "" + (numberOfRemainingCircles - 1);
            thirdCircleText.text = "" + (numberOfRemainingCircles - 2);
        }
    }

    IEnumerator newLevel()
    { 
           
            rotatingCircle.GetComponent<Rotate>().enabled = false;
            mainCircle.GetComponent<MainCircle>().enabled = false;
            animator.SetTrigger("newLevel");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);    
    }

   
}

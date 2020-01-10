using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagerScript : MonoBehaviour
{

    private void Start()
    {
        //PlayerPrefs.DeleteKey("save");
    }

    public void startGame()
    {
        int level = PlayerPrefs.GetInt("save");
        if(level==0)
        {
            SceneManager.LoadScene("1");
        }
        else
        {
            SceneManager.LoadScene("" + level);

        }



    }

    public void resetGame()
    {
        PlayerPrefs.SetInt("save", 0);
    }

    public void quitGame()
    {
        Application.Quit();

        //Unity'de çalışmaz bu kod. Build edilmesi lazım.

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string newGameScene;
    public string loadGameScene;

    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Current_Scene"))
        {
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            continueButton.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        SceneManager.LoadScene(loadGameScene);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

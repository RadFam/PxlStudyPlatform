using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnProceedClicked()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void OnSoundClicked()
    {
        Time.timeScale = 1;
        GameGlobalController.instance.OnOffSound();
        gameObject.SetActive(false);
    }

    public void OnMainMenuClicked()
    {
        Time.timeScale = 1;
        GameGlobalController.instance.LoadGameScene("menuScene");
        //gameObject.SetActive(false);
    }

    public void OnExitGameClicked()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Application.Quit();
    }
}

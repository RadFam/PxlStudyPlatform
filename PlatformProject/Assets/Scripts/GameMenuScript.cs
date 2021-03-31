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
        gameObject.SetActive(false);
    }

    public void OnSoundClicked()
    {
        gameObject.SetActive(false);
    }

    public void OnMainMenuClicked()
    {
        gameObject.SetActive(false);
    }

    public void OnExitGameClicked()
    {
        gameObject.SetActive(false);
        Application.Quit();
    }
}

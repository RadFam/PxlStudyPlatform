using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGlobalController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    AudioSource mySource;
    public static GameGlobalController instance;

    [SerializeField]
    bool audioOn;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }

    public void OnOffSound()
    {
        audioOn = !audioOn;
        if (!audioOn)
        {
            mySource.Stop();
        }
        else
        {
            mySource.Play();
        }
    }

    public void LoadGameScene(string gameScene)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "menuScene")
        {
            MenuMainPanelScript menuMainPanelScript = FindObjectOfType<MenuMainPanelScript>();
            menuMainPanelScript.gameObject.SetActive(false);
        }
        else
        {
            GameMenuScript gameMenuScript = FindObjectOfType<GameMenuScript>();
            gameMenuScript.gameObject.SetActive(false);
        }
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameScene, LoadSceneMode.Single);
    }
    
}

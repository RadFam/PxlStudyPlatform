using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGlobalController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    AudioSource mySource;
    [SerializeField]
    Image fadeImage;
    public static GameGlobalController instance;
    List<string> sceneNames = new List<string>{"menuScene", "mainScene", "mainScene_1", "mainScene_2", "mainScene_3"};

    [SerializeField]
    bool audioOn;
    float fadeAlpha;

    string sceneToLoad;
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
        sceneToLoad = gameScene;
        if (scene.name == "menuScene")
        {
            MenuMainPanelScript menuMainPanelScript = FindObjectOfType<MenuMainPanelScript>();
            if (menuMainPanelScript != null)
            {
                menuMainPanelScript.gameObject.SetActive(false);
            }
        }
        else
        {
            GameMenuScript gameMenuScript = FindObjectOfType<GameMenuScript>();
            if (gameMenuScript != null)
            {
                gameMenuScript.gameObject.SetActive(false);
            }
        }
        
        StartCoroutine(LoadChooseScene());
        //AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameScene, LoadSceneMode.Single);
    }

    public void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        int ind = sceneNames.FindIndex(x => x == scene.name);
        if (ind == sceneNames.Count-1)
        {
            LoadGameScene("menuScene");
        }
        else if (ind >= 0)
        {
            LoadGameScene(sceneNames[ind+1]);
        }
    }

    IEnumerator LoadChooseScene()
    {
        yield return StartCoroutine(FadeIn());
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return StartCoroutine(FadeOut());

    }

    public IEnumerator FadeIn()
    {
        fadeAlpha = 0.0f;
        Color blackC = Color.black;

        for (int i = 0; i < 25; ++i)
        {
            blackC = new Color(0.0f, 0.0f, 0.0f, fadeAlpha);
            fadeAlpha += 0.04f;
            fadeImage.color = blackC;
            yield return new WaitForSeconds(0.01f);
        }

        blackC = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        fadeImage.color = blackC;

        yield return null;
    }

    public IEnumerator FadeOut()
    {
        fadeAlpha = 1.0f;
        Color blackC = Color.black;

        for (int i = 0; i < 25; ++i)
        {
            blackC = new Color(0.0f, 0.0f, 0.0f, fadeAlpha);
            fadeAlpha -= 0.04f;
            fadeImage.color = blackC;
            yield return new WaitForSeconds(0.01f);
        }

        blackC = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        fadeImage.color = blackC;

        yield return null;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMainPanelScript : MonoBehaviour
{
    [SerializeField]
    MenuChooseLevelScript menuChooseLevelScript;
    // Start is called before the first frame update
    void Start()
    {
        menuChooseLevelScript.gameObject.SetActive(false);
    }

    public void OnChooseLevelClick()
    {
        menuChooseLevelScript.gameObject.SetActive(true);
    }

    public void OnExitGameClick()
    {
        Application.Quit();
    }
    
}

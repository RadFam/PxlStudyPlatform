using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChooseLevelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChooseLevel(int numButton)
    {
        string sceneName = "";
        if (numButton == 1)
        {
            sceneName = "mainScene";
        }
        if (numButton == 2)
        {
            sceneName = "mainScene_1";
        }
        if (numButton == 3)
        {
            sceneName = "mainScene_2";
        }
        if (numButton == 4)
        {
            sceneName = "mainScene_3";
        }

        gameObject.SetActive(false);
        GameGlobalController.instance.LoadGameScene(sceneName);
    }
}

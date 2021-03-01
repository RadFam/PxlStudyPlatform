using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIController : MonoBehaviour
{
    public Slider mySlider;
    
    public void EnableSlider() 
    {
        mySlider.gameObject.SetActive(true);
        mySlider.value = 1.0f;    
    }

    public void SetHealthRes(int currHlth, int maxHlth)
    {
        if (!mySlider.gameObject.activeInHierarchy)
        {
            EnableSlider();
        }
        float val = (float)currHlth / ((float)maxHlth);
        mySlider.value = val;
    }
}

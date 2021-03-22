using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst {get; private set;}

    public Dictionary<GameObject, HealthController> healthContainer;
    public Dictionary<GameObject, CoinController> coinContainer;
    public Dictionary<GameObject, HealthKitController> healthKitContainer;

    void Awake() 
    {
        inst = this;
        healthContainer = new Dictionary<GameObject, HealthController>();
        coinContainer = new Dictionary<GameObject, CoinController>();
        healthKitContainer = new Dictionary<GameObject, HealthKitController>();
    }

}

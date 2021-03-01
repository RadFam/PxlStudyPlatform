using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolShootObjects : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Arrows")]
    public List<GameObject> listFreeArrows = new List<GameObject>();
    public List<GameObject> listBusyArrows = new List<GameObject>();
}

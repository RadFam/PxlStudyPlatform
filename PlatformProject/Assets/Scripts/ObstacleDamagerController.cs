using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamagerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int damage;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.inst.healthContainer[col.gameObject].ReduceHealth(damage);
        }
    }
}

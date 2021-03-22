using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTriggerDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int damage;
    [SerializeField]
    Collider2D myCollider;

    public int Damage
    {
        get {return damage;}
        set {damage = value;}
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }

        var HealthController = other.gameObject.GetComponent<HealthController>();    
        if (HealthController != null)
        {
            HealthController.ReduceHealth(damage);
        }
        
        ArrowControl ac = GetComponent<ArrowControl>();
        //myCollider.isTrigger = false;
        Debug.Log(gameObject.name + " is triggered on " + other.gameObject.name);
        ac.StopArrow();
    }
}

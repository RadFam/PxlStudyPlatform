using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Animator myAnim;
    bool isTaken;
    Collider2D myCollider;

    public bool IsTaken
    {
        get {return isTaken;}
    }

    void Start() 
    {
        GameManager.inst.coinContainer.Add(gameObject, this);
        isTaken = false;
        myCollider = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    public void OnTake()
    {
        if (!isTaken)
        {
            isTaken = true;
            myCollider.enabled = false;
            myAnim.SetTrigger("CoinTaken");
        }
    }

    public void SelfDestroy(int a)
    {
        Destroy(this.gameObject);
    }
}

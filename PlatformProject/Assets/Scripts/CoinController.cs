using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Animator myAnim;

    void Start() 
    {
        GameManager.inst.coinContainer.Add(gameObject, this);
    }
    // Update is called once per frame
    public void OnTake()
    {
        myAnim.SetTrigger("CoinTaken");
    }

    public void SelfDestroy(int a)
    {
        Destroy(this.gameObject);
    }
}

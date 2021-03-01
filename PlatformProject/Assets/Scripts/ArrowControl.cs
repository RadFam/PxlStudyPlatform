using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    // Start is called before the first frame update
    public PoolShootObjects poolShoot;

    [SerializeField]
    Rigidbody2D myRigidBody;

    [SerializeField]
    SpriteRenderer mySpriteRndr;

    [SerializeField]
    float myForce;

    [SerializeField]
    float arrowLifeTime;

    public float MyForce
    {
        get {return myForce;}
        set {myForce = value;}
    }

    public void OnEnable() 
    {
        poolShoot.listBusyArrows.Add(gameObject);
        poolShoot.listFreeArrows.RemoveAt(0);
    }

    public void SetImpulse(Vector2 direction, int force)
    {
        myRigidBody.AddForce(direction * myForce * force, ForceMode2D.Impulse);
        StartCoroutine(ArrowLive());
    }

    IEnumerator ArrowLive()
    {
        yield return new WaitForSeconds(arrowLifeTime);

        EndAll();

        yield break;
    }

    void EndAll()
    {
        poolShoot.listFreeArrows.Add(gameObject);
        poolShoot.listBusyArrows.RemoveAt(0);
        gameObject.SetActive(false);
    }

    public void StopArrow()
    {
        StopCoroutine(ArrowLive());
        EndAll();
    }
}

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
    Collider2D myCollider;

    [SerializeField]
    SpriteRenderer mySpriteRndr;

    [SerializeField]
    float myForce;

    [SerializeField]
    float arrowLifeTime;

    bool deactive;

    public float MyForce
    {
        get {return myForce;}
        set {myForce = value;}
    }

    public void OnEnable() 
    {
        Debug.Log(gameObject.name + " is OnEnabled");
        poolShoot.listBusyArrows.Add(gameObject);
        poolShoot.listFreeArrows.RemoveAt(0);
        //myCollider.isTrigger = true;
        deactive = false;
        Debug.Log("Free list: " + poolShoot.listFreeArrows.Count + "  Busy list:" + poolShoot.listBusyArrows.Count);
    }

    public void SetImpulse(Vector2 direction, int force)
    {
        myRigidBody.AddForce(direction * myForce * force, ForceMode2D.Impulse);
        if (force < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
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
        if (!deactive)
        {
            deactive = true;
            Debug.Log(gameObject.name + " is OnDisabled");
            poolShoot.listFreeArrows.Add(gameObject);
            poolShoot.listBusyArrows.RemoveAt(0);
            Debug.Log("Free list: " + poolShoot.listFreeArrows.Count + "  Busy list:" + poolShoot.listBusyArrows.Count);
            gameObject.SetActive(false);
        }
    }

    public void StopArrow()
    {
        Debug.Log(gameObject.name + " StopArrow() function");
        StopCoroutine(ArrowLive());
        EndAll();
    }
}

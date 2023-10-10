using System.Collections;
using System.Collections.Generic;
using Health;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour {

    [SerializeField] private int damage = 1;
    [SerializeField] private float bulletSpeed = 5;
    private LayerMask layer;
    private Transform target;
    private Vector3 direction;
    private EnemyHealth _enemyHealth;

    public void Seek (Transform _target)
    {
        target = _target;
        
       
        Rigidbody body = GetComponent<Rigidbody>();
        transform.forward = direction;
        body.useGravity = false;
        body.AddForce(direction * bulletSpeed, ForceMode.VelocityChange);
        
    }
    void Update () {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    void HitTarget ()
    {
        int calculatedDamage = Mathf.RoundToInt(damage);
        
        if (_enemyHealth != null)
        {
            _enemyHealth.TakeDamage(calculatedDamage); 
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.gameObject.name);
        //Debug.Log("Hit");
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            //Debug.Log("Hit");
            enemyHealth.TakeDamage(damage);
        }
        // if(!other.isTrigger)
        // {
        //     if(((1 << other.gameObject.layer) & layer) != 0)
        //     {
        //          Debug.Log(other.gameObject.name);
        //          EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        //         Debug.Log();
        //         enemyHealth.TakeDamage(damage);
        //     }
        //
        //     Destroy(gameObject);
        // }
    }
}
using System.Collections;
using System.Collections.Generic;
using Health;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour {

    [SerializeField] private float damage = 10;
    [SerializeField] private float bulletSpeed = 5;
    private LayerMask layer;
    private Transform target;
    private Vector3 direction;
    private EnemyHealth enemyHealth;

    public void Seek (Transform _target)
    {
        target = _target;
        
       // layer = layerMask;
       
        Rigidbody body = GetComponent<Rigidbody>();
        //body.useGravity = false;
        
        transform.forward = direction;
        
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
        /*
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(target);
        }
        */
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.isTrigger)
        {
            if(((1 << other.gameObject.layer) & layer) != 0)
            {
                other.GetComponent<EnemyHealth>();
            }

            Destroy(gameObject);
        }
    }
}
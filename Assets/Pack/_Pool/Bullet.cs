using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : GameUnit
{
    //public Rigidbody rb;
    float speed = 5f;
    public void OnInit()
    {
        
    }
    public void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }


    private void OnTriggerEnter(Collider other)
    {
        //ParticlePool.Play(ParticleType.Hit_1, transform.position, Quaternion.identity);
        OnDespawn();
    }
}

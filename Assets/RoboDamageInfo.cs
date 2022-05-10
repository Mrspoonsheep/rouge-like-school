using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboDamageInfo : MonoBehaviour
{
    public int damage;
    Bullet Bullet;
    const float bulletDespawnDelay = 0.001f;
    public void Awake()
    {
        damage = (int)Bullet.DamageNumbers.Robot;
    }

    // Update is called once per frame
    public void Update()
    {
        GetComponent<BoxCollider2D>();

    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hit detected");
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

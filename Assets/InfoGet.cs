using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGet : MonoBehaviour
{
    public int damage;
    Bullet Bullet;
    const float bulletDespawnDelay = 0.001f;
    public void Awake()
    {
        damage = (int)Bullet.DamageNumbers.Pistol;
    }

    // Update is called once per frame
    public void Update()
    {
        GetComponent<BoxCollider2D>();

    }
}

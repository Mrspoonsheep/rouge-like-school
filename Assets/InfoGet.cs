using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGet : MonoBehaviour
{
    int damage;
    Bullet Bullet;
    public void Start()
    {
        damage = (int)Bullet.DamageNumbers.Pistol;
    }

    // Update is called once per frame
    public void Update()
    {
        GetComponent<BoxCollider2D>();

    }

   public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit detected");
        if (col.gameObject.tag == "Wall")
        {
            Debug.Log("Hit Wall");
            GameObject.Destroy(gameObject);
        }
    }
}

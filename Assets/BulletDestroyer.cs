using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    //destroy incoming bullets to eliminate them from worldspace
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("has triggered");
        if(collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}

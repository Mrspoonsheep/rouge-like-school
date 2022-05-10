using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Transform player;
    public float speed = 100f;
    public float angle;
    public Quaternion rotation;
    bool allowforfire = true;
    [SerializeField] float bulletSpeed;
    public float waitTilNextFire = 0.0f;
    private void Update()
    {
        Vector2 direction = player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        if(player.position.x < transform.parent.position.x)
        {
             transform.localPosition = new Vector2(-0.155f, 0f);
        }
        else
        {
            transform.localPosition = new Vector2(0.155f, 0f);
        }
    }
    public void Shoot(GameObject bullet)
    {
        var clone = Instantiate(bullet, transform.position, transform.rotation);
        var bulletRb = clone.GetComponent<Rigidbody2D>();
        bulletRb.velocity = transform.right * bulletSpeed;
        clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y, -1f);
    }
}


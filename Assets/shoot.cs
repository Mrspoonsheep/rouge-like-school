using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    GameObject Bullet, bulletSpawner, clone;
    PointTowardMouse point;
    Vector2 bulletVelocity;
    public float bulletSpeed = 2;
    void Start()
    {
        Bullet = GameObject.Find("bullet");
        point = GetComponentInParent<PointTowardMouse>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log($"input on mouse is: {Input.GetKeyDown(KeyCode.Mouse0)}");
            clone = Instantiate(Bullet, transform.position, point.rotation);
            var bulletRb = clone.GetComponent<Rigidbody2D>();
            bulletRb.velocity = transform.right * bulletSpeed;
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y, -1);
        }

    }
}

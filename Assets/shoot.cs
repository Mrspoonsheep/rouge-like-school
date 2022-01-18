using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject Bullet;
    PointTowardMouse point;
    Vector2 bulletVelocity;
    public float bulletSpeed = 2;
    void Start()
    {
        point = GetComponentInParent<PointTowardMouse>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log($"input on mouse is: {Input.GetKeyDown(KeyCode.Mouse0)}");
            var clone = Instantiate(Bullet, transform.position, point.rotation);
            var bulletRb = clone.GetComponent<Rigidbody2D>();
            bulletRb.velocity = transform.right * bulletSpeed;
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y, -1);
        }
    }
}

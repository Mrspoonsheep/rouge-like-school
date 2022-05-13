using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float speed = 100f;
    public float angle;
    public Quaternion rotation;
    public GameObject Bullet;
    [SerializeField]PointTowardMouse point;
    Vector2 bulletVelocity;
    public float bulletSpeed = 2f;
    public Transform BulletEjector;
    public playercontrol accessor;
    [SerializeField] Animator animator;
    void Start()
    {
        point = GetComponentInParent<PointTowardMouse>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        if (accessor.shouldFlip == true)
        {
            transform.localPosition = new Vector2(0.224f, -0.016f);
        }
        else
        {
            transform.localPosition = new Vector2(0.224f, 0.016f);
        }
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.Play("gunShoot");
            var clone = Instantiate(Bullet, transform.position, point.rotation);
            var bulletRb = clone.GetComponent<Rigidbody2D>();
            bulletRb.velocity = transform.right * bulletSpeed;
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y, -1);
        }
    }
}

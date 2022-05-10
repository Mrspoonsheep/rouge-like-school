using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTowardMouse : MonoBehaviour
{
    public float speed = 100f;
    public float angle;
    public Quaternion rotation;

    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboAI : MonoBehaviour
{
    public int robohealth = 4;
    public float speed = 0.2f;
    public float minMoveDist = 1f;
    [SerializeField] Transform target;

    private void Update()
    {
        if (target != null)
        {

            float zeroer = speed * Time.deltaTime;
           
            float PositionDelta = Vector2.Distance(transform.position, target.position);
                transform.position = Vector2.MoveTowards(transform.position, target.position, zeroer);
        }
    }

    private void LateUpdate()
    {
        target = Findtarget();
    }

    Transform Findtarget()
    {
        if (target == null)
        {
            Transform _target = GameObject.FindGameObjectWithTag("Player").transform;
            if (_target != null)
            {
                return _target;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return target;
        }
    }
}
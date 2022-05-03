using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboAI : MonoBehaviour
{
    public float speed = 3f;
    public float detectdistance = 5f;
    public float minMoveDist = 1f;
    [SerializeField] Transform target;

    private void Update()
    {
        if (target != null)
        {
           
            Vector2 PositionDelta = transform.position - target.position;
            if (PositionDelta.x >= minMoveDist && PositionDelta.y >= minMoveDist)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
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
            Transform _target;
            try
            {
                _target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            catch
            {
                return null;
            }
            if (_target != null)
            {
                float _dist = Vector2.Distance(_target.position, transform.position);
                if (_dist <= detectdistance)
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
                return null;
            }
        }
        else
        {
                float _dist = Vector2.Distance(target.position, transform.position);
                if (_dist <= detectdistance)
                {
                    return target;
                }
                else
                {
                    return null;
                }
        }
    }

}

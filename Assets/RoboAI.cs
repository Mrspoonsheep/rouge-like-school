using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class RoboAI : MonoBehaviour
{
    public int robohealth = 4;
    public float speed = 0.2f;
    public float minMoveDist = 3f;
    public SpriteRenderer roboSprite;
    Vector3 oldPos;
    public Animator roboAnim;
    [SerializeField] Transform target;
    public GameObject roboBullet;
    public EnemyShoot shootScript;
    public float fireRate, waitTilNextFire = 1.0f;

    void Start()
    {
        FindObjectOfType<GameController>().OnEnemySpawn();
    }

    private void Update()
    { 
        if (target == null)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (robohealth <= 0)
        {
            Destroy(gameObject, 1.0f); 
        }


        if (target != null)
        {
            float trueSpeed;
            float PositionDelta = Vector2.Distance(transform.position, target.position);
            if(PositionDelta < minMoveDist)
            {
                trueSpeed = 0f;
                
            }
            else
            {
                trueSpeed = speed * Time.deltaTime;
            }
            
            transform.position = Vector2.MoveTowards(transform.position, target.position, trueSpeed);

            if (oldPos != transform.position)
            {
                roboAnim.SetBool("ShouldWalk", true);
            }
            else 
            {
                if (waitTilNextFire <= 0.0f)
                {
                    shootScript.Shoot(roboBullet);
                    waitTilNextFire = 1.0f;
                }
                waitTilNextFire -= fireRate * Time.deltaTime;
                roboAnim.SetBool("ShouldWalk", false);
            }
            

            oldPos = transform.position;
        }
        
        roboSprite.flipX = transform.position.x > target.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            InfoGet d = collision.gameObject.GetComponent<InfoGet>();
            robohealth -= d.damage;
            Destroy(collision.gameObject);
        }
    }
    void LateUpdate()
    {
        
        target = Findtarget();
    }


    void OnDestroy()
    {
        FindObjectOfType<GameController>()?.OnEnemyDeath();
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
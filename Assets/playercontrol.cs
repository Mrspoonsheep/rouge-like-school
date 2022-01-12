using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class playercontrol : MonoBehaviour
{
    public float movementSpeed = 5f;

    public Rigidbody2D rb;
    private int teleportlength { get; set; }
    Vector2 movement, lastplace, lastPos, lastDifference;
    Transform movementAction;
    public GameObject player;
    public SpriteRenderer characterSprite;
    public SpriteRenderer armSprite;
    public PointTowardMouse accessedScript;
    public Animator bodyAnim;


    private Vector2 FindGameObjPos(string strgameobj)
    {
        GameObject gameobj = GameObject.FindGameObjectWithTag(strgameobj);

        Debug.Assert(gameobj != null);

        Vector2 playerState = gameobj.transform.position;
        return playerState;
    }
    private void Start()
    {
        // = GetComponentInChildren<Animator>();
    }
    Vector2 Teleport(Vector2 playerState, Vector2 dir)
    {
        playerState += dir;
        rb.MovePosition(playerState);
        // Debug.Log($"distanceX = {distanceX} and distanceY = {distanceY}");
        return playerState;
    }
    void Update()
    {
        bool shouldFlip = accessedScript.angle > 90f || accessedScript.angle < -90f;
        Vector2 playerState = FindGameObjPos("Player");
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(moveX, moveY);
        if (!shouldFlip)
        {
            switch (moveX)
            {
                case -1f:
                    bodyAnim.SetBool("walkingBackward", true);
                    bodyAnim.SetBool("Walking", false);
                break;
                case 1f:
                    bodyAnim.SetBool("Walking", true);
                    bodyAnim.SetBool("walkingBackward", false);
                break;
                default:
                    bodyAnim.SetBool("walkingBackward", false);
                    bodyAnim.SetBool("Walking", false);
                    break;
            }
            
        }
        else if (shouldFlip)
        {
            switch (moveX)
            {
                case -1f:
                    bodyAnim.SetBool("walkingBackward", false);
                    bodyAnim.SetBool("Walking", true);
                    break;
                case 1f:
                    bodyAnim.SetBool("Walking", false);
                    bodyAnim.SetBool("walkingBackward", true);
                    break;
                default:
                    bodyAnim.SetBool("walkingBackward", false);
                    bodyAnim.SetBool("Walking", false);
                    break;
            }
        }
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        // if  (Input.GetKeyDown(KeyCode.LeftShift) && playerState.x - lastplace.x != 0 && playerState.y - lastplace.y != 0)
        if (Input.GetKeyDown(KeyCode.LeftShift) && rb.velocity.sqrMagnitude > 0.1)
        {
            Teleport(playerState, moveDirection * 2);
            Debug.Log($"playerState = {playerState}");
        }
        //Debug.Log($"moveX = {moveX} and moveY = {moveY}");
        movement = new Vector2(moveX, moveY).normalized;
        lastplace = FindGameObjPos("Player");


        characterSprite.flipX = shouldFlip;
        armSprite.flipY = shouldFlip;
    }
    private bool CheckDirection()
    {
        
        Vector2 currentpos = transform.position;
        float difference = currentpos.x - lastPos.x;

        return false;
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * movementSpeed, movement.y * movementSpeed);
    }
    public void StartAnimPlayback(playercontrol p, string animName)
    {
        //p.bodyAnim.ResetTrigger(animName);
        p.bodyAnim.SetTrigger(animName);
    }
}

public class Container
{

}
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class playercontrol : MonoBehaviour
{
    public float movementSpeed = 5f;

    public Rigidbody2D rb;
    private int teleportlength { get; set; }
    Vector2 movement, lastplace;
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
        Vector2 playerState = FindGameObjPos("Player");
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(moveX, moveY);

        bodyAnim.SetBool("Walking", move.sqrMagnitude > 0.001);

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

        bool shouldFlip = accessedScript.angle > 90f || accessedScript.angle < -90f;

        characterSprite.flipX = shouldFlip;
        armSprite.flipY = shouldFlip;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * movementSpeed, movement.y * movementSpeed);
        //if (movement.x != 0 || movement.y != 0)
        //{
        //    Container.StartAnimPlayback(this, "fWalkTrigger");
        //}
        //else
        //{
        //    Container.StartAnimPlayback(this, "stopWalkTrigger");
        //}
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
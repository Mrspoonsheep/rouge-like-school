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

    private Vector2 FindGameObjPos(string strgameobj)
    {
        GameObject gameobj = GameObject.FindGameObjectWithTag(strgameobj);

        Debug.Assert(gameobj != null);
        
        Vector2 playerState = gameobj.transform.position;
        return playerState;
    }
    Vector2 Teleport(Vector2 playerState, float X, float Y)
    {
        float distanceY = 0.5f * Y + playerState.y;
        float distanceX = 0.5f * X + playerState.x;
        playerState = new Vector2(distanceX,distanceY).normalized;
        rb.MovePosition(playerState);
        Debug.Log($"distanceX = {distanceX} and distanceY = {distanceY}");
        return playerState;
    }
    void Update()
    {
        Vector2 playerState = FindGameObjPos("Player");
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(moveX, moveY);
        if  (Input.GetKeyDown(KeyCode.LeftShift) && playerState.x - lastplace.x != 0 && playerState.y - lastplace.y != 0)
        {
            Teleport(playerState, moveX, moveY);
            Debug.Log($"playerState = {playerState}");
        }
        //Debug.Log($"moveX = {moveX} and moveY = {moveY}");
        movement = new Vector2(moveX, moveY).normalized;
        lastplace = FindGameObjPos("Player");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * movementSpeed, movement.y * movementSpeed);
    }
}

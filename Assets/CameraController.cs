using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    public float strength = 2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        Vector2 playerPos = player.transform.position;
        if ((pos - playerPos).sqrMagnitude < 0.1) return;
        var rel = playerPos - pos;

        pos += rel.normalized* rel.sqrMagnitude * Time.fixedDeltaTime * strength;
        transform.position = new Vector3(pos.x, pos.y, -10f);
    }
}

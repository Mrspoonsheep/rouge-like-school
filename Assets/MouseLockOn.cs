using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLockOn : MonoBehaviour
{
    Vector3 worldMousePos = new Vector3();
    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {
        worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePos.z = 0f;
        transform.position = worldMousePos;
    }
}

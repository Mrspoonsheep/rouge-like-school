using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LvlGen : MonoBehaviour
{
    float origin;
    
    float calcworldpoint(int distance)
    {
        float result = (float)(0.32 * distance);
        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void GenBox() 
    {
        int distance = new System.Random().Next(15, 100);
    }
}

public class Room
{
    List<float> origins = new List<float>();
    float origin;

}
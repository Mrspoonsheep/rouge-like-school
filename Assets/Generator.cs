using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    Vector2 worldSize = new Vector2(4, 4);
    Room[,] rooms;
    List<Vector2> takenPositions = new List<Vector2>();
    int gridSizeX, gridSizeY, numberOfRooms = 20;
    public GameObject roomWhiteObj;
    public Transform mapRoot;
    void Start()
    {
        if(numberOfRooms >= (worldSize.x * 2) * (worldSize.y * 2)) // make sure we dont try to make more rooms than can fit in our grid
        {

        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
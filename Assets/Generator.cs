using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private System.Random rand = new System.Random();
    private Transform spawnerTransform, roomTransform;
    public GameObject spawner;
    private float xpos, ypos, preNumber;
    int gridMiddle;
    void Start()
    {
        spawnerTransform = spawner.transform;
        int gridVariationX = rand.Next(99, 199);
        int gridVariationY = rand.Next(59, 99);
        Grid generationGrid = new Grid(gridVariationX, gridVariationY, 32f, spawnerTransform);
        preNumber = (gridVariationX / 2) - 0.5f;
        string strNumber = strNumber = preNumber.ToString();

        if(!(gridVariationX%2 == 0))
        {
        try
        {
            Debug.Log($"strNumebr = {strNumber}");
            gridMiddle = int.Parse(strNumber);
        }
        catch (Exception c)
        {
            print(c);
        }
        }
        for(int i = 0; i < generationGrid.gridCells.Count; i++)
        {
            if(generationGrid.gridCells[i].Position.x == generationGrid.gridCells[gridVariationX].Position.x)
            {
                if (generationGrid.gridCells[i].Position.y == generationGrid.gridCells[4].Position.y)
                {
                    roomTransform.position = generationGrid.gridCells[i].Position;
                    UnityEngine.Object room = GameObject.Find("Bfab");
                    GameObject gameRoom = GameObject.Find("Bfab");
                    Instantiate(room, generationGrid.gridCells[i].Position, gameRoom.transform.rotation);
                }
            }
            else if(generationGrid.gridCells[i].Position.x == generationGrid.gridCells[gridMiddle].Position.x)
            {
                if (generationGrid.gridCells[i].Position.y == generationGrid.gridCells[4].Position.y)
                {
                    roomTransform.position = generationGrid.gridCells[i].Position;
                    UnityEngine.Object room = GameObject.Find("Bfab");
                    GameObject gameRoom = GameObject.Find("Bfab");
                    Instantiate(room, generationGrid.gridCells[i].Position, gameRoom.transform.rotation);
                }
            }
            else
            {

            }
        }

    }
}
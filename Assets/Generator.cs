using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum DoorSides
{
    L = 1,
    R = 2,
    B = 4,
    T = 8,
    LR = L | R,
    BL = L | B,
    LT =L | T,
    LBT = L | B | T,
    LBR = L | B | R,
    LBRT = L | B | R | T,
    RT = R | T,
    BT = T |B,
}

[System.Serializable]
public struct RoomTemplate
{
    public DoorSides doors;
    public GameObject prefab;
}

public class Generator : MonoBehaviour
{
    private System.Random rand = new System.Random();
    private Transform spawnerTransform;
    public GameObject spawner;
    int gridMiddle;
    Grid grid;

    public RoomTemplate[] roomTemplates;

    private Dictionary<DoorSides, int> roomTemplateMap;

    public void Start()
    {
        GenerateRoomMap();
        GenerateGrid();
    }

    void GenerateGrid() { 
        spawnerTransform = spawner.transform;

        int gridWidth = rand.Next(5, 10);
        int gridHeight = rand.Next(5, 10);
        grid = new Grid(gridWidth, gridHeight, 128f, spawnerTransform);
        // Middle index
        int midY = gridHeight / 2;
        int midX = gridWidth / 2;


        for (int x = 0; x < grid.Width; x++)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                // Get top row middle column
                // Since y increases, the y coordinate is height-1
                if (x == midX && y == grid.Height - 1)
                {
                    Spawn(DoorSides.B, x, y);
                }
                else
                {
                    Spawn(DoorSides.BT, x, y);
                }
            }

        }
    }

    void Spawn(DoorSides sides, int x, int y)
    {
        var roomTemplate = roomTemplates[roomTemplateMap[sides]];
        Instantiate(roomTemplate.prefab, grid[x, y].Position, Quaternion.identity, transform);
    }

    void GenerateRoomMap()
    {
        roomTemplateMap = new Dictionary<DoorSides, int>();
        for(int i = 0; i < roomTemplates.Length; i++)     
        {
            roomTemplateMap.Add(roomTemplates[i].doors, i);
        }
    }
}
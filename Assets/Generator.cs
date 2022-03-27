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
    private Vector2 spawningPos;
    public GameObject spawner;
    int gridMiddle;
    Grid grid;

    public RoomTemplate[] roomTemplates;

    private Dictionary<DoorSides, int> roomTemplateMap;

    public void Start()
    {
        //GenerateRoomMap();
        GenerateGrid();
    }

    public void GenerateGrid() { 
        spawningPos = spawner.transform.position;
        int gridWidth = rand.Next(25, 50);
        int gridHeight = rand.Next(50, 100);
        grid = new Grid(gridWidth, gridHeight, 32f, spawningPos);
        // Middle index
        int midY = gridHeight / 2;
        int midX = gridWidth / 2;
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
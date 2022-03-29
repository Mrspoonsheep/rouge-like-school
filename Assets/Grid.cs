using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Grid
{
    private int height;
    private int width;
    int[,] grid;
    private Cell[,] cells;
    private List<Cell> cellList = new List<Cell>();
    private Vector2 spawnerPos;
    private float cellSize;

    public Cell this /* is sparta */ [int x, int y] {
        get {
            return cells[x, y];
        }
        set
        {
            cells[x, y] = value;
        }
    }

    public Vector2 startingPos { get { return spawnerPos; } }
    public int Count { get { return cells.Length; } }
    public int Width { get => width; private set => width = value; }
    public int Height { get => height; private set => height = value; }

    public Grid(int width, int height, float cellSize, Vector2 spawnerPos)
    {
        Width = width;
        Height = height;

        this.spawnerPos = spawnerPos;
        float spawnerPosX = spawnerPos.x;
        float spawnerPosY = spawnerPos.y;

        const float UnitsPerPixels = 0.01f;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var position = new Vector2(
                                (UnitsPerPixels * cellSize * x) + spawnerPosX,
                                (UnitsPerPixels * cellSize * y) + spawnerPosY);
                Cell c = new Cell(false, position);
                cellList.Add(c);
            }
        }

    }
    public Cell GetCell(int x, int y)
    {
        Cell c;
        const float UnitsPerPixels = 0.01f;
        float spawnerPosX = spawnerPos.x;
        float spawnerPosY = spawnerPos.y;
        var position = new Vector2(
                                (UnitsPerPixels * cellSize * x) + spawnerPosX,
                                (UnitsPerPixels * cellSize * y) + spawnerPosY);
        foreach(var cell in cellList)
        {
            if(cell.Position == position)
            {
                c = cell;
                return c;
            }
        }
        throw new ArgumentException();
    }
}

public struct Cell
{
    public Vector2 Position;
    public bool active;
    public Cell(bool active, Vector2 position)
    {
        this.active = active;
        this.Position = position;
    }
}
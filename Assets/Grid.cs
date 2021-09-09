using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int width, height;
    private float cellSize = 0.64f;
    private int[,] grid;
    private List<Cell> gridCells = new List<Cell>();
    public Grid(int width, int height, float cellSize, Transform Spawner)
    {
        this.width = width;
        this.height = height;

        grid = new int[width, height];
        Vector2 posContainer;
        for(int x = 0; x < grid.GetLength(0); x++)
        {
            for(int y = 0; y < grid.GetLength(1); y++)
            {
                Cell c = new Cell(false, new Vector2(x * cellSize, y * cellSize));
                gridCells.Add(c);
                posContainer.x = x;
                posContainer.y = y;
            }
        }

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
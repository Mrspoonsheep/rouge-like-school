using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int width, height;
    private int[,] grid;
    public List<Cell> gridCells = new List<Cell>();
    public Grid(int width, int height, float cellSize, Transform spawner)
    {
        this.width = width;
        this.height = height;

        grid = new int[width, height];
        float spawnerPosX = spawner.position.x;
        float spawnerPosY = spawner.position.y;

        const float UnitsPerPixels = 0.01f;

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                var position = new Vector2(
                        (UnitsPerPixels * cellSize * x) + spawnerPosX,
                        (UnitsPerPixels * cellSize * y) + spawnerPosY);

                Cell c = new Cell(false, position);

                gridCells.Add(c);
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
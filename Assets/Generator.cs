using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private System.Random rand = new System.Random();
    private Transform spawnerTransform;
    public GameObject spawner;
    private float xpos, ypos;
    void Start()
    {
        spawnerTransform = spawner.transform;
        int gridVariationX = rand.Next(99, 199);
        int gridVariationY = rand.Next(59, 99);
        Grid generationGrid = new Grid(gridVariationX, gridVariationY, 32f, spawnerTransform);
        
        for(int i = 0; i < generationGrid.gridCells.Count; i++)
        {
            if(generationGrid.gridCells[i].Position.x == generationGrid.gridCells[gridVariationX/2].Position.x)
            {

            }
            else if(generationGrid.gridCells[i].Position.x == generationGrid.gridCells[(gridVariationX/2) - gridVariationX % 2].Position.x)
            {

            }
        }
    }
}
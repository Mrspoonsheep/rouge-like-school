using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private System.Random rand = new System.Random();
    private Transform spawnerTransform;
    public GameObject spawner;
    void Start()
    {
        spawnerTransform = spawner.transform;
        int gridVariationX = rand.Next(400, 1000);
        int gridVariationY = rand.Next(200, 500);
        Grid generationGrid = new Grid(gridVariationX, gridVariationY, 0.64f, spawnerTransform);
        
        for(int i = 0; i < generationGrid.gridCells.Count; i++)
        {
            
        }
    }
}
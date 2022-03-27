using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class Edge
{
    public Vector2 pos;
    public Vector2 normal;

    public Edge(Vector2 pos, Vector2 normal)
    {
        this.pos = pos;
        this.normal = normal;
    }
}

public class LvlGen : MonoBehaviour
{
    int numberOfcuts = new System.Random().Next(5, 25);
    List<Floor> floors;
    // Start is called before the first frame update
    void Start()
    {
        

        for (int i = 0; i < 1; i++)
        {
            Floor floor = new Floor();

            // Create rooms
            // Dictionary<Tuple<int, int>, bool> edges = new Dictionary<Tuple<int, int>, bool>();
            List<Edge> edges = new List<Edge>();
            System.Random rand = new System.Random();
            for (int j = 0; j < 4; j++)
            {
                
                int index = rand.Next(0, edges.Count);

                int sizeX = rand.Next(2, 5);
                int sizeY = rand.Next(2, 5);
                var edge = edges[index];
                Vector2 origin = edge.pos + new Vector2((float)sizeX, (float)sizeY) * edge.normal;
                Vector2 spawningPos = new Vector2(origin.x - (Floor.calcworldpoint(sizeX) / 2f), origin.y - (Floor.calcworldpoint(sizeY) / 2f));
                var room = Room.Create(sizeX, sizeY, origin, spawningPos);
                for ()
                {

                }
                edges.RemoveAt(index);
                floor.rooms.Add(room);
                edges.AddRange(room.Edges().Where(x => Vector2.Dot(x.normal, edge.normal) - 1.0 > 0.1));
            }
            floors.Add(floor);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class Floor
{
    public List<Room> rooms = new List<Room>();

    public float sizeY, sizeX;
    float[,] origin = new float[1, 1];

    public static float calcworldpoint(int distance)
    {
        float result = (float)(0.32f * distance);
        return result;
    }

}

public class Room
{
    public float sizeY, sizeX;
    Vector2 origin;
    public Grid grid;
    Room(float sizex, float sizey, Vector2 roomOrigin, Grid grid)
    {
        this.sizeX = sizex;
        this.sizeY = sizey;
        this.origin = roomOrigin;
        this.grid = grid;
    }

    public Edge[] Edges()
    {
        return new Edge[] {
            new Edge(origin + new Vector2((float)sizeX, 0f), Vector2.right),
            new Edge(origin + new Vector2(-(float)sizeX, 0f), Vector2.left),
            new Edge(origin + new Vector2(0f, (float)sizeY), Vector2.up),
            new Edge(origin + new Vector2(0f, (float)-sizeY), Vector2.down),
            };
    }

    public static Room Create(int sizex, int sizey, Vector2 origin, Vector2 spawningPos)
    {
        
        
        
        origin = new Vector2(Floor.calcworldpoint(sizex)/2f, Floor.calcworldpoint(sizey)/2f);
        
        Grid grid = new Grid(sizex, sizey, 32f,spawningPos);
        Room room = new Room(sizex, sizey, origin, grid);
        return room;
    }
}
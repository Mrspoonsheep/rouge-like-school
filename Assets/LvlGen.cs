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
                var room = Room.Create(sizeX, sizeY, origin);

                edges.RemoveAt(index);
                floor.rooms.Add(room);
                edges.AddRange(room.Edges().Where(x => Vector2.Dot(x.normal, edge.normal) - 1.0 > 0.1));
            }
            floors.Add(floor);
        }
        for (int i = 0; i <= numberOfcuts; i++)
        {
            int cutDir = new System.Random().Next(0, 1);
            if (cutDir == 1)
            {

            }
            else
            {

            }
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
    Room(float sizex, float sizey, Vector2 roomOrigin)
    {
        this.sizeX = sizex;
        this.sizeY = sizey;
        this.origin = roomOrigin;
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

    public static Room Create(int sizey, int sizex, Vector2 origin)
    {
        var sizeY = Floor.calcworldpoint(sizey);
        var sizeX = Floor.calcworldpoint(sizex);
        var origin = new Vector2();
        Room room = new Room(sizeX, sizeY, origin);
        return room;
    }
}
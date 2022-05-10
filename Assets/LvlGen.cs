using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
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
    int enemiesLeft;
    Cell tempCell;
    public List<Floor> floors;
    public GameObject[] gameSprites;
    public GameObject enemy;
    [SerializeField] Scene scene;
    // Start is called before the first frame update
    public void Start()
    {
        Cursor.visible = false;
        for (int i = 0; i < 1; i++)
        {
            
            Floor floor = new Floor();
            Edge edge;
            List<Edge> edges = new List<Edge>();
            floors = new List<Floor>();
            System.Random rand = new System.Random();
            
            for (int j = 0; j < 1; j++)
            {
                int index = rand.Next(0, edges.Count);
                Debug.Log($"{index}, {edges.Count}");
                int sizeX = rand.Next(20, 50);
                int sizeY = rand.Next(20, 50);
                // Random or initial edge
                if (edges.Count > 0)
                {
                    edge = edges[index];
                }
                else
                {
                    edge = new Edge(Vector2.zero, Vector2.up);
                }
                Debug.Log($"the edge is at position {edge.pos}");
                Vector2 origin = edge.pos + new Vector2(Floor.calcworldpoint(sizeX) / 2f, Floor.calcworldpoint(sizeY) / 2f) * edge.normal;
                Debug.Log($"new vector is = {new Vector2(Floor.calcworldpoint(sizeX) / 2f, Floor.calcworldpoint(sizeY) / 2f) * edge.normal}");
                Vector2 spawningPos = new Vector2(origin.x - (Floor.calcworldpoint(sizeX) / 2f), origin.y - (Floor.calcworldpoint(sizeY) / 2f));
                var room = Room.Create(sizeX, sizeY, origin, spawningPos);
                Debug.Log("Creating room");
                if (edges.Count() != 0) edges.RemoveAt(index);
                floor.rooms.Add(room);
                edges.AddRange(room.Edges().Where(x => Vector2.Dot(x.normal, edge.normal) - 1.0 > 0.1));
                int floorTile = new System.Random().Next(0, 2);
                for (int k = 0; k < room.grid.Width; k++)
                {
                    for (int l = 0; l < room.grid.Height; l++)
                    {
                        int rand2 = new System.Random().Next(0, 100);
                       
                        bool left = k == 0;
                        bool right = k == room.grid.Width - 1;
                        bool top = l == 0;
                        bool bot = l == room.grid.Height - 1;

                        tempCell = room.grid.GetCell(k, l);

                        Debug.Log($"Using tileP {floorTile}. Avail: {gameSprites.Length}");
                        var cell = Instantiate(gameSprites[floorTile], tempCell.Position, Quaternion.AngleAxis(0f, new Vector3(0, 0, 0)));
                        bool isonleftedge = tempCell.Position.x == room.grid.GetCell(0, 0).Position.x;
                        if (rand2 <= 50)
                        {
                            Spawner(tempCell.Position, enemy);
                            enemiesLeft++;
                        }
                        if (left)
                        {
                            Instantiate
                            (
                                gameSprites[3],
                                new Vector2(tempCell.Position.x, tempCell.Position.y),
                                Quaternion.AngleAxis(0f, new Vector3(0, 0, 0))
                            );
                        }
                        if (right)
                        {
                            Instantiate
                            (
                                gameSprites[4],
                                new Vector2(tempCell.Position.x, tempCell.Position.y),
                                Quaternion.AngleAxis(0f, new Vector3(0, 0, 0))
                            );
                        }
                        if (top)
                        {
                            Instantiate
                            (
                                gameSprites[5],
                                new Vector2(tempCell.Position.x, tempCell.Position.y),
                                Quaternion.AngleAxis(0f, new Vector3(0, 0, 0))
                            );
                        }
                        if (bot)
                        {
                            Instantiate
                            (
                                gameSprites[6],
                                new Vector2(tempCell.Position.x, tempCell.Position.y),
                                Quaternion.AngleAxis(0f, new Vector3(0, 0, 0))
                            );


                        }

                    }
                }

                floors.Add(floor);
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                enemiesLeft = enemies.Length;
                if (enemiesLeft <= 0)
                {
                    SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
                }
            }
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 20), "Enemies Remaining : " + enemiesLeft);
    }

    public void Spawner(Vector2 location, GameObject Enemy)
    {

        Instantiate(Enemy, location, Quaternion.Euler(0, 0, 0));

    }

} 
public struct Spawner
{
    Vector2 Pos;
    GameObject npc;
    public Spawner(Vector2 position, GameObject NPC)
    {
        this.Pos = position;
        this.npc = NPC;
    }

    //public GameObject[] NPCs = new GameObject[2];

}
public class Floor
{
    public List<Room> rooms = new List<Room>();


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

    public static Room Create(int width, int height, Vector2 origin, Vector2 spawningPos)
    {
        origin = origin + new Vector2(Floor.calcworldpoint(width) / 2f, Floor.calcworldpoint(height) / 2f);

        Grid grid = new Grid(width, height, 32f, spawningPos);
        Room room = new Room(width, height, origin, grid);
        return room;
    }
}
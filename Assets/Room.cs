using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo
{
    int x;
    int y;
    

    public int type;
    public bool onSame, doorTop, doorBot, doorLeft, doorRight;
    Vector2 doorPosition;
    public RoomInfo(Vector2 _gridPos, int _type)
    {
        
        type = _type;
    }
}

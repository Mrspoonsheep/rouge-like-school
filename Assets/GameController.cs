using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 

public class GameController : MonoBehaviour
{
    public LvlGen getLvlGen;
    public delegate void removeEnemy();
    RoboAI Robot;
    public void Update()
    {
        Robot.EneiesMinusOne += Robot_EneiesMinusOne; ;
    }

    private void Robot_EneiesMinusOne()
    {
        getLvlGen.enemiesLeft -= -1;
    }
}

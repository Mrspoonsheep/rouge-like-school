using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public LvlGen getLvlGen;
    int enemyCount = 0;
    void Start()
    {
    }


    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 20), "Enemies Remaining : " + enemyCount);
    }

    public void OnEnemyDeath()
    {
        enemyCount -= 1;
        if (enemyCount == 0)
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }
    }

    public void OnEnemySpawn()
    {
        enemyCount += 1;
    }

}

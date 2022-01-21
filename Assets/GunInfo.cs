using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInfo : MonoBehaviour
{
    private void Start()
    {
        
    }
    private class gun
    {
        public string gunName;
        public float firerate;

        gun(string Gun, float FireRate)
        {
            Gun = this.gunName;
            FireRate = this.firerate;
        }
    }
}

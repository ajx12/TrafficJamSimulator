using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : SafeDriver
{

    bool activated = false;
    int targetLane = 1;
    // Start is called before the first frame update
    void Start()
    {
        thisCar = this.gameObject;
        Lane1 = mainSpawner.L1List;
        Lane2 = mainSpawner.L2List;
        Lane3 = mainSpawner.L3List;
        whichLaneStart();
        activated = true;
    }


    int count = 0;
    int cooldown = 0;
    // Update is called once per frame
    void Update()
    {
        if (activated == true)
        {
            base.moveTheCar();
        }
    }
}

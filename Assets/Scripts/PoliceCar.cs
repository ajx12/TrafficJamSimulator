using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : SafeDriver
{


    // Start is called before the first frame update
    void Start()
    {
        thisCar = this.gameObject;
        Lane1 = mainSpawner.L1List;
        Lane2 = mainSpawner.L2List;
        Lane3 = mainSpawner.L3List;
        whichLaneStart();
        activated = true;
        ShiftOnCooldown = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (activated == true)
        {
            mainSpawner.isPoliceCar = true;
            base.moveTheCar();
        }
    }

    public override void deleteTheCar(int currentIndex)
    {
        lane.RemoveAt(currentIndex);
        Destroy(thisCar);
        mainSpawner.isPoliceCar = false;
        activated = false;
    }
}

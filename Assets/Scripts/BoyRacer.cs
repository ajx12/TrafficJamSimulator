using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyRacer : SimpleCar
{
    //Orange car
    GameObject thisCar;

    // Start is called before the first frame update
    void Start()
    {
        thisCar = this.gameObject;
        this.speed = 70;
        Lane1 = mainSpawner.L1List;
        Lane2 = mainSpawner.L2List;
        Lane3 = mainSpawner.L3List;
        whichLaneStart();
    }

    // Update is called once per frame
    void Update()
    {
        moveTheCar();
    }


    int count = 0;
    public override void moveTheCar()
    {
        transform.Translate(userDirection * speed * Time.deltaTime);
        int currentIndex = lane.IndexOf(thisCar);
        // z pos needs to be at most 10 away from the car in front.
        GameObject carInfront = (GameObject)lane[currentIndex-1];
        if (carInfront.transform.position.z - thisCar.transform.position.z <= 10)
        {
            speed -= 5;
        }


        //once the car reaches the end of the road:
        if (transform.position.z > 500)
        {
            lane.RemoveAt(currentIndex);
            Destroy(thisCar);
        }
    }

    private void whichLaneStart()
    {
        print("Lane 1 count: " + Lane1.Count + "Lane 2 count: " + Lane2.Count + "Lane 3 count:" + Lane3.Count);
        if (Lane1.Contains(thisCar))
        {
            print("Found in lane 1");
            lane = Lane1;
            return;
        }
        if (Lane2.Contains(thisCar))
        {
            print("Found in lane 2");
            lane = Lane2;
            return;
        }
        if (Lane3.Contains(thisCar))
        {
            print("Found in lane 3");
            lane = Lane3;
            return;
        }
        print("Wasn't found in any lane");
        return;
    }

}

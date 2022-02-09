using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyRacer : SimpleCar
{
    //Orange car
    GameObject thisCar;
    bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        thisCar = this.gameObject;
        this.speed = 60;
        Lane1 = mainSpawner.L1List;
        Lane2 = mainSpawner.L2List;
        Lane3 = mainSpawner.L3List;
        whichLaneStart();
        activated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated == true)
        {
            moveTheCar();
        }
    }


    int count = 0; // after every set frames, the car speed will increase.
    public override void moveTheCar()
    {
        if (count == 20 && speed < 81)
        {
            count = 0;
            speed++;
        }
        else if (count < 15)
        {
            count++;
        }
        transform.Translate(userDirection * speed * Time.deltaTime);
        int currentIndex = lane.IndexOf(thisCar);
        // z pos needs to be at most 10 away from the car in front.
        if (currentIndex != 0)
        {
            GameObject carInfront = (GameObject)lane[currentIndex - 1];
            SimpleCar carInfrontAttributes = carInfront.GetComponent<SimpleCar>();
            float distanceDifference = 0;

            distanceDifference = carInfront.transform.position.z - thisCar.transform.position.z;
            if (distanceDifference <= 15)
            {
                //print("difference is " + distanceDifference + "when the two things are" + carInfront.transform.position.z + " - " + thisCar.transform.position.z);
                speed = carInfrontAttributes.speed - 1;
            }
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
        //print("Lane 1 count: " + Lane1.Count + "Lane 2 count: " + Lane2.Count + "Lane 3 count:" + Lane3.Count);
        if (Lane1.Contains(thisCar))
        {
            //print("Found in lane 1");
            lane = Lane1;
            return;
        }
        if (Lane2.Contains(thisCar))
        {
            //print("Found in lane 2");
            lane = Lane2;
            return;
        }
        if (Lane3.Contains(thisCar))
        {
            //print("Found in lane 3");
            lane = Lane3;
            return;
        }
        print("Wasn't found in any lane");
        return;
    }

}

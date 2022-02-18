using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailGater : SimpleCar
{
    //Red Car
    
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


    int count = 0;
    public override void moveTheCar()
    {
        if (count == 15)
        {
            if (speed < 76)
            {
                speed++;
            }
            if (holdingSomeoneUp == true && isMergingLane == false)
            {
                tryToMoveInwards();
            }
            count = 0;
        }
        else if (count < 15)
        {
            count++;
        }
        transform.Translate(userDirection * speed * Time.deltaTime);
        int currentIndex = lane.IndexOf(thisCar);

        // z pos needs to be at most 10 away from the car in front.
        if (currentIndex > 0)
        {
            GameObject carInfront = (GameObject)lane[currentIndex - 1];
            SimpleCar carInfrontAttributes = carInfront.GetComponent<SimpleCar>();
            if (isMergingLane == true)
            {
                if (thisCar.transform.position.x <= carInfront.transform.position.x)
                {
                    isMergingLane = false;
                    holdingSomeoneUp = false;
                    userDirection = Vector3.forward;
                }
            }
            float distanceDifference = 0;

            distanceDifference = carInfront.transform.position.z - thisCar.transform.position.z;
            if (distanceDifference <= 15)
            {
                //print("difference is " + distanceDifference + "when the two things are" + carInfront.transform.position.z + " - " + thisCar.transform.position.z);
                speed = carInfrontAttributes.speed;
                carInfrontAttributes.holdingSomeoneUp = true;
            }
        }

        if (transform.position.z > 500)
        {
            lane.RemoveAt(currentIndex);
            Destroy(thisCar);
        }
    }

    protected void tryToMoveInwards()
    {
        ArrayList prevLane = new ArrayList();
        if (lane == Lane1)
        {
            unableToShift = true;
        }
        if (lane == Lane2)
        {
            prevLane = Lane1;
        }
        if (lane == Lane3)
        {
            prevLane = Lane2;
        }
        if (lane == Lane2 || lane == Lane3)
        {
            float currentPos = thisCar.transform.position.z;
            float upperBound = currentPos + 5; //further in front of the car. (addition becuase cars are heading towards z point 500)
            float lowerBound = currentPos - 10; // further behind of the car.
            bool exceptionFound = false;
            for (int i = 0; i < prevLane.Count; i++)
            {
                GameObject x = (GameObject)prevLane[i];
                if (x.transform.position.z < upperBound && x.transform.position.z > lowerBound)
                {
                    //we have found a car too close so do not attempt lane shift
                    exceptionFound = true;
                    print(thisCar + "   Can't shift lanes yet.");
                    i = prevLane.Count; //end the for loop
                }
            }
            if (exceptionFound == false)
            {
                userDirection = Vector3.forward + Vector3.left;
                isMergingLane = true;
                int indexToInsertAt = findindexForLaneInsertion(prevLane);
                prevLane.Insert(indexToInsertAt, thisCar);
                lane.Remove(thisCar);
                lane = prevLane;
            }
            else
            {
                unableToShift = true;
            }
        }

    }

    private int findindexForLaneInsertion(ArrayList prevLane)
    {
        float currZ = thisCar.transform.position.z;
        for (int i = 0; i < prevLane.Count; i++)
        {
            GameObject x = (GameObject)prevLane[i];
            if (x.transform.position.z < currZ)
            {
                return i - 1;
            }
        }
        return -1;
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
        //print("Wasn't found in any lane");
        return;
    }

}

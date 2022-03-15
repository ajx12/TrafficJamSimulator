using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleCar : MonoBehaviour
{
    public float speed = 60;
    public Vector3 userDirection = Vector3.forward;

    public bool holdingSomeoneUp = false; //if set to true, try to move to another lane to let the person behind you through

    public bool beingHeldUp = false; //if set to true, this car is being held up, will try to move lanes.

    public bool isMergingLane = false; //a bool to check if a car is merging lane 

    public bool unableToShift = false; //there is another car obstructing the lane in the desired direction

    protected string directionShifting = "";

    protected bool ShiftOnCooldown = false;
    protected int currentShiftCooldown = 0;

    public ArrayList lane;
    protected double currLaneX;
    protected float laneSpeed;
    protected ArrayList Lane1;
    protected ArrayList Lane2;
    protected ArrayList Lane3;
    protected ArrayList desiredLane;
    protected GameObject thisCar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTheCar();
        
    }

    protected void tryToMoveInwards()
    {
        desiredLane = new ArrayList();
        float newSpeedIfSuccessful = 0;
        double newLaneX = 0;
        if (lane == Lane1)
        {
            unableToShift = true;
        }
        if (lane == Lane2)
        {
            desiredLane = Lane1;
            newSpeedIfSuccessful = mainSpawner.maxSpeedL1;
            newLaneX = mainSpawner.L1X;
        }
        if (lane == Lane3)
        {
            desiredLane = Lane2;
            newSpeedIfSuccessful = mainSpawner.maxSpeedL2;
            newLaneX = mainSpawner.L2X;
        }
        if (lane == Lane2 || lane == Lane3)
        {
            float currentPos = thisCar.transform.position.z;
            float upperBound = currentPos + 18; //further in front of the car. (addition becuase cars are heading towards z point 500)
            float lowerBound = currentPos - 15; // further behind of the car.
            bool exceptionFound = false;
            for (int i = 0; i < desiredLane.Count; i++)
            {
                GameObject x = (GameObject)desiredLane[i];
                if (x.transform.position.z < upperBound && x.transform.position.z > lowerBound)
                {
                    //we have found a car too close so do not attempt lane shift
                    exceptionFound = true;
                    print(thisCar + "   Can't shift lanes yet.");
                    i = desiredLane.Count; //end the for loop
                }
            }
            if (exceptionFound == false)
            {
                ShiftOnCooldown = true;
                userDirection = Vector3.forward + Vector3.left;
                isMergingLane = true;
                int indexToInsertAt = findindexForLaneInsertion(desiredLane);
                desiredLane.Insert(indexToInsertAt, thisCar);
                lane.Remove(thisCar);
                lane = desiredLane;
                laneSpeed = newSpeedIfSuccessful;
                directionShifting = "left";
                currLaneX = newLaneX;
            }
            else
            {
                unableToShift = true;
            }
        }

    }

    private int findindexForLaneInsertion(ArrayList otherLane)
    {
        float currZ = thisCar.transform.position.z;
        for (int i = 0; i < otherLane.Count; i++)
        {
            GameObject x = (GameObject)otherLane[i];
            if (x.transform.position.z < currZ)
            {
                return i;
            }
        }
        return 0;
    }


    protected void tryToOvertake()
    {
        desiredLane = new ArrayList();
        float newSpeedIfSuccessful = 0;
        double newLaneX = 0;
        if (lane == Lane1)
        {
            desiredLane = Lane2;
            newSpeedIfSuccessful = mainSpawner.maxSpeedL2;
            newLaneX = mainSpawner.L2X;
        }
        if (lane == Lane2)
        {
            desiredLane = Lane3;
            newSpeedIfSuccessful = mainSpawner.maxSpeedL3;
            newLaneX = mainSpawner.L3X;
        }
        if (lane == Lane3)
        {
            unableToShift = true;
        }
        if (lane == Lane1 || lane == Lane2)
        {
            float currentPos = thisCar.transform.position.z;
            float upperBound = currentPos + 12; //further in front of the car. (addition becuase cars are heading towards z point 500)
            float lowerBound = currentPos - 30; // further behind of the car.
            bool exceptionFound = false;
            for (int i = 0; i < desiredLane.Count; i++)
            {
                GameObject x = (GameObject)desiredLane[i];
                if (x.transform.position.z < upperBound && x.transform.position.z > lowerBound)
                {
                    //we have found a car too close so do not attempt lane shift
                    exceptionFound = true;
                    print(thisCar + "   Can't shift lanes yet.");
                    i = desiredLane.Count; //end the for loop
                }
            }
            if (exceptionFound == false)
            {
                ShiftOnCooldown = true;
                userDirection = Vector3.forward + Vector3.right;
                isMergingLane = true;
                int indexToInsertAt = findindexForLaneInsertion(desiredLane);
                desiredLane.Insert(indexToInsertAt, thisCar);
                lane.Remove(thisCar);
                lane = desiredLane;
                speed = speed + 5;
                laneSpeed = newSpeedIfSuccessful;
                directionShifting = "right";
                currLaneX = newLaneX;
            }
            else
            {
                unableToShift = true;
            }
        }

    }

    protected void whichLaneStart()
    {
        //print("Lane 1 count: " + Lane1.Count + "Lane 2 count: " + Lane2.Count + "Lane 3 count:" + Lane3.Count);
        if (Lane1.Contains(thisCar))
        {
            //print("Found in lane 1");
            lane = Lane1;
            laneSpeed = mainSpawner.maxSpeedL1;
            speed = laneSpeed - 5;
            currLaneX = mainSpawner.L1X;
            return;
        }
        if (Lane2.Contains(thisCar))
        {
            //print("Found in lane 2");
            lane = Lane2;
            laneSpeed = mainSpawner.maxSpeedL2;
            speed = laneSpeed - 15;
            currLaneX = mainSpawner.L2X;
            return;
        }
        if (Lane3.Contains(thisCar))
        {
            //print("Found in lane 3");
            lane = Lane3;
            laneSpeed = mainSpawner.maxSpeedL3;
            speed = laneSpeed - 20;
            currLaneX = mainSpawner.L3X;
            return;
        }
        print("Wasn't found in any lane");
        return;
    }


    public abstract void moveTheCar();

}
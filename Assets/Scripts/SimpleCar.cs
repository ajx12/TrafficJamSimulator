using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleCar : MonoBehaviour
{
    public int speed = 60;
    public Vector3 userDirection = Vector3.forward;
    public bool holdingSomeoneUp = false; //if set to true, try to move to another lane to let the person behind you through
    public bool beingHeldUp = false; //if set to true, this car is being held up, will try to move lanes.
    public bool isMergingLane = false; //a bool to check if a car is merging lane 
    public bool unableToShift = false; //there is another car obstructing the lane in the desired direction
    public ArrayList lane;
    protected ArrayList Lane1;
    protected ArrayList Lane2;
    protected ArrayList Lane3;
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
            float upperBound = currentPos + 10; //further in front of the car. (addition becuase cars are heading towards z point 500)
            float lowerBound = currentPos - 12; // further behind of the car.
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
        return -1;
    }



    public abstract void moveTheCar();
}

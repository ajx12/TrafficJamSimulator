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
    int cooldown = 0;
    public override void moveTheCar()
    {
        if (ShiftOnCooldown == true)
        {
            cooldown++;
            if (cooldown == 75)
            {
                ShiftOnCooldown = false;
                cooldown = 0;
            }
        }
        if (count >= 6)
        {
            if (speed < laneSpeed + 12)
            {
                speed = speed + 2;
            }
            count = 0;
        }
        else if (count < 6)
        {
            count++;
        }
        if (holdingSomeoneUp == true && isMergingLane == false && ShiftOnCooldown == false)
        {
            tryToMoveInwards();
        }
        if (lane == Lane1 && beingHeldUp == true && isMergingLane == false && ShiftOnCooldown == false)
        {
            tryToOvertake();
        }
        transform.Translate(userDirection * speed * Time.deltaTime);
        int currentIndex = lane.IndexOf(thisCar);

        // z pos needs to be at most 10 away from the car in front.
        if (currentIndex == 0) //if they hold someone up when they're at the front
        {
            if (isMergingLane == true)
            {
                GameObject carBehind = (GameObject)lane[currentIndex + 1];
                if (thisCar.transform.position.x <= carBehind.transform.position.x)
                {
                    isMergingLane = false;
                    holdingSomeoneUp = false;
                    userDirection = Vector3.forward;
                    speed = laneSpeed - 10;
                }
            }
        }
        if (currentIndex > 0)
        {
            GameObject carInfront = (GameObject)lane[currentIndex - 1];
            GameObject backCar = (GameObject)lane[lane.Count - 1];
            SimpleCar carInfrontAttributes = carInfront.GetComponent<SimpleCar>();
            if (isMergingLane == true)
            {
                if (directionShifting == "left")
                {
                    if (thisCar.transform.position.x <= backCar.transform.position.x)
                    {
                        isMergingLane = false;
                        holdingSomeoneUp = false;
                        userDirection = Vector3.forward;
                        beingHeldUp = false;
                        speed = laneSpeed - 10;
                    }
                }
                else
                {
                    if (thisCar.transform.position.x >= backCar.transform.position.x)
                    {
                        isMergingLane = false;
                        holdingSomeoneUp = false;
                        userDirection = Vector3.forward;
                        beingHeldUp = false;
                    }
                }
            }
            float distanceDifference = 0;

            distanceDifference = carInfront.transform.position.z - thisCar.transform.position.z;
            if (distanceDifference <= 10)
            {
                //print("difference is " + distanceDifference + "when the two things are" + carInfront.transform.position.z + " - " + thisCar.transform.position.z);
                speed = carInfrontAttributes.speed;
                beingHeldUp = true;
            }
            if (distanceDifference <= 15)
            {
                carInfrontAttributes.holdingSomeoneUp = true;
            }
        }

        if (transform.position.z > 500)
        {
            lane.RemoveAt(currentIndex);
            Destroy(thisCar);
        }
    }


}

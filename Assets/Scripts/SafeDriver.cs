using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeDriver : SimpleCar
{

    //Black Car
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
        int currentIndex = lane.IndexOf(thisCar);
        int distanceFromStart = lane.Count - currentIndex;
        if (ShiftOnCooldown == true)
        {
            cooldown++;
            if (cooldown == 200)
            {
                ShiftOnCooldown = false;
                cooldown = 0;
            }
        }
        if (count >= 8)
        {
            if (speed < laneSpeed + 6 && beingHeldUp == false)
            {
                speed = speed + 2;
            }
            count = 0;
        }
        else if (count < 8)
        {
            count++;
        }
        if (holdingSomeoneUp == true && isMergingLane == false && ShiftOnCooldown == false && distanceFromStart > 5)
        {
            tryToMoveInwards();
        }
        if (beingHeldUp == true && isMergingLane == false && ShiftOnCooldown == false && distanceFromStart > 5)
        {
            tryToOvertake();
        }
        transform.Translate(userDirection * speed * Time.deltaTime);
        currentIndex = lane.IndexOf(thisCar);
        // z pos needs to be at most 10 away from the car in front.
        if (currentIndex == 0)
        {
            if (isMergingLane == true)
            {
                if (directionShifting == "left")
                {
                    if (thisCar.transform.position.x <= currLaneX)
                    {
                        speed = laneSpeed;
                        isMergingLane = false;
                        holdingSomeoneUp = false;
                        userDirection = Vector3.forward;
                        beingHeldUp = false;
                        speed = laneSpeed - 10;
                    }
                }
                else
                {
                    if (thisCar.transform.position.x >= currLaneX)
                    {
                        speed = laneSpeed;
                        isMergingLane = false;
                        holdingSomeoneUp = false;
                        userDirection = Vector3.forward;
                        beingHeldUp = false;
                    }
                }
            }
        }
        if (currentIndex > 0)
        {
            if (isMergingLane == true)
            {
                if (directionShifting == "left")
                {
                    if (thisCar.transform.position.x <= currLaneX)
                    {
                        speed = laneSpeed;
                        isMergingLane = false;
                        holdingSomeoneUp = false;
                        userDirection = Vector3.forward;
                        beingHeldUp = false;
                        speed = laneSpeed - 10;
                    }
                }
                else
                {
                    if (thisCar.transform.position.x >= currLaneX)
                    {
                        speed = laneSpeed;
                        isMergingLane = false;
                        holdingSomeoneUp = false;
                        userDirection = Vector3.forward;
                        beingHeldUp = false;
                    }
                }

            }
            
        }
        currentIndex = lane.IndexOf(thisCar);
        if (currentIndex > 0)
        {
            GameObject carInfront = (GameObject)lane[currentIndex - 1];
            SimpleCar carInfrontAttributes = carInfront.GetComponent<SimpleCar>();
            float distanceDifference;

            distanceDifference = carInfront.transform.position.z - thisCar.transform.position.z;
            if (distanceDifference <= 14)
            {
                //print("difference is " + distanceDifference + "when the two things are" + carInfront.transform.position.z + " - " + thisCar.transform.position.z);
                speed = carInfrontAttributes.speed;
                beingHeldUp = true;
            }
            if (distanceDifference <= 16)
            {
                carInfrontAttributes.holdingSomeoneUp = true;
            }
        }


            //once the car reaches the end of the road:
            if (transform.position.z > 500)
        {
            lane.RemoveAt(currentIndex);
            Destroy(thisCar);
        }
    }



}

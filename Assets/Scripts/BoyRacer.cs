using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyRacer : SimpleCar
{
    //Orange car
    bool activated = false;
    int targetLane = 3;
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
            moveTheCar();
        }
    }


    int count = 0; // after every set frames, the car speed will increase.
    int cooldown = 0;
    public override void moveTheCar()
    {
        int currentIndex = lane.IndexOf(thisCar);
        int distanceFromStart = lane.Count - currentIndex;
        if (ShiftOnCooldown == true)
        {
            cooldown++;
            if (cooldown == 2000)
            {
                ShiftOnCooldown = false;
                cooldown = 0;
                if (currentLane != targetLane && isMergingLane == false && ShiftOnCooldown == false && distanceFromStart > 5 && mainSpawner.isAmbulance2 == false)
                {
                    if (currentLane < targetLane)
                    {
                        tryToOvertake();
                    }
                    if (currentLane > targetLane)
                    {
                        tryToMoveInwards();
                    }
                }
            }
        }
        if (count >= 6)
        {
            if (speed < laneSpeed + 20 && beingHeldUp == false)
            {
                speed = speed + 2;
            }
            count = 0;
        }
        else if (count < 6)
        {
            count++;
        }
        if (mainSpawner.isPoliceCar == true && beingHeldUp == false)
        {
            speed = laneSpeed;
        }
        if (holdingSomeoneUp == true && isMergingLane == false && ShiftOnCooldown == false && mainSpawner.isAmbulance2 == false)
        {
            tryToMoveInwards();
        }
        if (beingHeldUp == true && isMergingLane == false && ShiftOnCooldown == false && distanceFromStart > 5 && mainSpawner.isAmbulance2 == false)
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
                        speed = laneSpeed - 10;
                        isMergingLane = false;
                        holdingSomeoneUp = false;
                        userDirection = Vector3.forward;
                        beingHeldUp = false;

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
            currentIndex = lane.IndexOf(thisCar);
            GameObject carInfront = (GameObject)lane[currentIndex - 1];
            SimpleCar carInfrontAttributes = carInfront.GetComponent<SimpleCar>();
            if (isMergingLane == true)
            {
                if (directionShifting == "left")
                {
                    if (thisCar.transform.position.x <= currLaneX)
                    {
                        speed = laneSpeed - 10;
                        speed = laneSpeed;
                        isMergingLane = false;
                        holdingSomeoneUp = false;
                        userDirection = Vector3.forward;
                        beingHeldUp = false;

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
            float distanceDifference = 0;

            distanceDifference = carInfront.transform.position.z - thisCar.transform.position.z;
            if (distanceDifference <= 12)
            {
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
            deleteTheCar(currentIndex);
        }
    }

    public override void deleteTheCar(int currentIndex)
    {
        lane.RemoveAt(currentIndex);
        Destroy(thisCar);
        activated = false;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SundayDriver : SimpleCar
{
    //Blue Car

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
        if (count >= 15)
        {
            if(speed < laneSpeed - 5 && beingHeldUp == false)
            {
                speed++;
            }
            count = 0;
        }
        else if (count < 15)
        {
            count++;
        }
        if (holdingSomeoneUp == true && isMergingLane == false && ShiftOnCooldown == false)
        {
            tryToMoveInwards();
        }
        transform.Translate(userDirection * speed * Time.deltaTime);
        int currentIndex = lane.IndexOf(thisCar);
        // z pos needs to be at most 10 away from the car in front.
        if (currentIndex == 0)
        {
            if (isMergingLane == true)
            {
                if (thisCar.transform.position.x <= currLaneX)
                {
                    speed = laneSpeed;
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
            SimpleCar carInfrontAttributes = carInfront.GetComponent<SimpleCar>();
            if (isMergingLane == true)
            {
                if (thisCar.transform.position.x <= currLaneX)
                {
                    speed = laneSpeed;
                    isMergingLane = false;
                    holdingSomeoneUp = false;
                    userDirection = Vector3.forward;
                    speed = laneSpeed - 10;
                }
            }
            float distanceDifference = 0;

            distanceDifference = carInfront.transform.position.z - thisCar.transform.position.z;
            if (distanceDifference <= 15)
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

        if (transform.position.z > 500)
        {
            lane.RemoveAt(currentIndex);
            Destroy(thisCar);
        }
    }




}

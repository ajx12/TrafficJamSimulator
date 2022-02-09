using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTraffic : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject RedCar;

    [SerializeField] GameObject BlueCar;

    [SerializeField] GameObject OrangeCar;

    [SerializeField] GameObject BlackCar;

    public GameObject Lane1;
    public GameObject Lane2;
    public GameObject Lane3;
    public GameObject theLane;

    int count = 0;

    int nextSpawn = 25;

    int whichLane = 0;

    void Start()
    {
        Lane1 = mainSpawner.L1;
        Lane2 = mainSpawner.L2;
        Lane3 = mainSpawner.L3;
        if (this.gameObject == Lane1)
        {
            whichLane = 1;
            theLane = Lane1;
        }
        if (this.gameObject == Lane2)
        {
            whichLane = 2;
            theLane = Lane2;
        }
        if (this.gameObject == Lane3)
        {
            whichLane = 3;
            theLane = Lane3;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count > nextSpawn)
        {
            count = 0;
            nextSpawn = Random.Range(22, 45);
            int whichColour = Random.Range(1, 5); //random from 1 to 2
            if (whichColour == 1)
            {
                print("Red");
                GameObject newCar = Instantiate(RedCar, transform);
                addNewCarToLane(newCar);
            }
            if (whichColour == 2)
            {
                print("Blue");
                GameObject newCar = Instantiate(BlueCar, transform);
                addNewCarToLane(newCar);
            }
            if (whichColour == 3)
            {
                print("Orange");
                GameObject newCar = Instantiate(OrangeCar, transform);
                addNewCarToLane(newCar);
            }
            if (whichColour == 4)
            {
                print("Black");
                GameObject newCar = Instantiate(BlackCar, transform);
                addNewCarToLane(newCar);
            }
        }
    }

    void addNewCarToLane(GameObject car)
    {
        if (theLane == Lane1)
        {
            mainSpawner.L1List.Add(car);
        }
        if (theLane == Lane2)
        {
            mainSpawner.L2List.Add(car);
        }
        if (theLane == Lane3)
        {
            mainSpawner.L3List.Add(car);
        }
    }

}

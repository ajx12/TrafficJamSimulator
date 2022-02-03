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

    int count = 0;

    int nextSpawn = 25;

    int whichLane = 0;

    void Start()
    {
        Lane1 = mainSpawner.L1;
        Lane2 = mainSpawner.L2;
        Lane3 = mainSpawner.L3;
        if (this == Lane1)
        {
            whichLane = 1;
        }
        if (this == Lane2)
        {
            whichLane = 2;
        }
        if (this == Lane3)
        {
            whichLane = 3;
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
            }
            if (whichColour == 2)
            {
                print("Blue");
                Instantiate(BlueCar, transform);
            }
            if (whichColour == 3)
            {
                print("Orange");
                Instantiate(OrangeCar, transform);
            }
            if (whichColour == 4)
            {
                print("Black");
                Instantiate(BlackCar, transform);
            }
        }
    }
}

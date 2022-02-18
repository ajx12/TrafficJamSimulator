using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTraffic : MonoBehaviour
{
    // Start is called before the first frame update

    int brChance; // boy racer chance (out of 20)
    int safeChance; // safe driver chance
    int sunChance; //sunday driver chance
    int tgChance; //tail gater chance

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


    void Start()
    {
        Lane1 = mainSpawner.L1;
        Lane2 = mainSpawner.L2;
        Lane3 = mainSpawner.L3;
        if (this.gameObject == Lane1)
        {
            theLane = Lane1;
            brChance = 1; // boy racer chance
            safeChance = 9; // safe driver chance
            sunChance = 19; //sunday driver chance
            tgChance = 20; //tail gater chance
        }
        if (this.gameObject == Lane2)
        {
            theLane = Lane2;
            brChance = 8; // boy racer chance
            safeChance = 12; // safe driver chance
            sunChance = 14; //sunday driver chance
            tgChance = 20; //tail gater chance
        }
        if (this.gameObject == Lane3)
        {
            theLane = Lane3;
            brChance = 10; // boy racer chance
            safeChance = 0; // safe driver chance
            sunChance = 0; //sunday driver chance
            tgChance = 20; //tail gater chance
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count > nextSpawn)
        {
            count = 0;
            nextSpawn = Random.Range(15, 30);
            int whichColour = Random.Range(1, 21); //random from 1 to 20
            if (brChance != 0)
            {
                if (whichColour <= brChance)
                {
                    //spawn a boy racer
                    GameObject newCar = Instantiate(OrangeCar, transform);
                    addNewCarToLane(newCar);
                    return;
                }
            }
            if (safeChance != 0)
            {
                if (whichColour <= safeChance) //we know from condition above that "whichColour" must be therefore larger than brChance
                {
                    GameObject newCar = Instantiate(BlackCar, transform);
                    addNewCarToLane(newCar);
                    return;
                }
            }
            if (sunChance != 0)
            {
                if (whichColour <= sunChance)
                {
                    GameObject newCar = Instantiate(BlueCar, transform);
                    addNewCarToLane(newCar);
                    return;
                }
            }
            if (tgChance != 0)
            {
                if (whichColour <= tgChance)
                {
                    GameObject newCar = Instantiate(RedCar, transform);
                    addNewCarToLane(newCar);
                    return;
                }
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

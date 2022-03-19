using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTraffic : MonoBehaviour
{
    // Start is called before the first frame update

    int brChance; // boy racer chance (out of 100)
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

    float upperChance;
    float lowerChance;
    double spawnerMultiplier;

    int count = 0;

    double nextSpawn = 25;


    void Start()
    {
        Lane1 = mainSpawner.L1;
        Lane2 = mainSpawner.L2;
        Lane3 = mainSpawner.L3;
        setVariables();
    }

    void setVariables()
    {
        bool L1open = mainSpawner.L1open;
        bool L2open = mainSpawner.L2open;
        bool L3open = mainSpawner.L3open;
        spawnerMultiplier = mainSpawner.sliderMultiplier;
        if (this.gameObject == Lane1)
        {
            theLane = Lane1;
            brChance = mainSpawner.ln1Br; // boy racer chance
            safeChance = mainSpawner.ln1Safe; // safe driver chance
            sunChance = mainSpawner.ln1Sun; //sunday driver chance
            tgChance = mainSpawner.ln1Tg; //tail gater chance
            if ((L1open == true) && (L2open == false || L3open == false))
            {
                if (L2open == false && spawnerMultiplier < 1.2){
                    spawnerMultiplier = 1.2;
                }
                if (L3open == false)
                {
                    if (L2open == false)
                    {
                        spawnerMultiplier = 1.5;
                    }
                    else
                    {
                        if (spawnerMultiplier < 1.2)
                        {
                            spawnerMultiplier = 1.2;
                        }
                    }
                }
            }


            lowerChance = (float)(25 / spawnerMultiplier);
            upperChance = (float)(35 / spawnerMultiplier);
            print("lane1 is low then up: " + lowerChance + " " + upperChance);
        }
        if (this.gameObject == Lane2)
        {
            theLane = Lane2;
            brChance = mainSpawner.ln2Br; // boy racer chance
            safeChance = mainSpawner.ln2Safe; // safe driver chance
            sunChance = mainSpawner.ln2Sun; //sunday driver chance
            tgChance = mainSpawner.ln2Tg; //tail gater chance
            if ((L2open == true) && (L1open == false || L3open == false))
            {
                if (L1open == false)
                {
                    spawnerMultiplier = 1.5;
                }
                if (L3open == false)
                {
                    if (L1open == false)
                    {
                        spawnerMultiplier = 3;
                    }
                    else
                    {
                        spawnerMultiplier = 1.5;
                    }
                }
            }
            lowerChance = (float)(25 / spawnerMultiplier);
            upperChance = (float)(35 / spawnerMultiplier);
            print("lane2 is low then up: " + lowerChance + " " + upperChance);
        }
        if (this.gameObject == Lane3)
        {
            theLane = Lane3;
            brChance = mainSpawner.ln3Br; // boy racer chance
            safeChance = mainSpawner.ln3Safe; // safe driver chance
            sunChance = mainSpawner.ln3Sun; //sunday driver chance
            tgChance = mainSpawner.ln3Tg; //tail gater chance
            if ((L3open == true) && (L1open == false || L2open == false))
            {
                if (L1open == false)
                {
                    spawnerMultiplier = 1.5;
                }
                if (L2open == false)
                {
                    if (L1open == false)
                    {
                        spawnerMultiplier = 3;
                    }
                    else
                    {
                        spawnerMultiplier = 1.5;
                    }
                }
            }
            lowerChance = (float)(35 / spawnerMultiplier);
            upperChance = (float)(45 / spawnerMultiplier);
            print("lane3 is low then up: " + lowerChance + " " + upperChance);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count > nextSpawn && isLaneOpen() == true)
        {
            setVariables();
            count = 0;
            nextSpawn = Random.Range(lowerChance, upperChance+1);
            int whichColour = Random.Range(1, 101); //random from 1 to 100
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

    bool isLaneOpen()
    {
        if (theLane == Lane1)
        {
            return mainSpawner.L1open;
        }
        if (theLane == Lane2)
        {
            return mainSpawner.L2open;
        }
        if (theLane == Lane3)
        {
            return mainSpawner.L3open;
        }
        return false;
    }

    bool isLaneOpen(GameObject thisLane)
    {
        if (thisLane == Lane1)
        {
            return mainSpawner.L1open;
        }
        if (thisLane == Lane2)
        {
            return mainSpawner.L2open;
        }
        if (thisLane == Lane3)
        {
            return mainSpawner.L3open;
        }
        return false;
    }

}

   

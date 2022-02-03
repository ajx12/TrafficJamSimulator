using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject Car;

    int count = 0;

    public GameObject[] laneArray = new GameObject[10000];
    int amountOfCars = 0;


    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count > 25)
        {
            count = 0;
            GameObject newCar = Instantiate(Car, transform);
            laneArray[amountOfCars + 1] = newCar;
            amountOfCars++;
        }
    }
}

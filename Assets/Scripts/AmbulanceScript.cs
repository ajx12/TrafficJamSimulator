using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceScript : SimpleCar
{
    public double target;
    public Vector3 direction;
    protected GameObject theAmbulance;
    // Start is called before the first frame update
    void Start()
    {
        thisCar = this.gameObject;
        direction = Vector3.forward + Vector3.left;
        speed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        moveTheCar();
    }

    public override void moveTheCar()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        double currentX = thisCar.transform.position.x;
        if (currentX <= target)
        {
            direction = Vector3.forward;
            speed = 80;
        }
        if (thisCar.transform.position.z > 500)
        {
            deleteTheCar(0);
        }
    }

    public override void deleteTheCar(int c)
    {
        Destroy(thisCar);
        mainSpawner.isAmbulance1 = false;
        mainSpawner.isAmbulance2 = false;
        mainSpawner.isAmbulance3 = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyRacer : SimpleCar
{
    // Start is called before the first frame update
    void Start()
    {
        this.speed = 70;
        Lane1 = mainSpawner.L1;
        Lane2 = mainSpawner.L2;
        Lane3 = mainSpawner.L3;
    }

    // Update is called once per frame
    void Update()
    {
        moveTheCar();
        int x = 2;
    }

    public override void moveTheCar()
    {
        transform.Translate(userDirection * speed * Time.deltaTime);
        if (transform.position.z > 500)
        {
            Destroy(this.gameObject);
        }
    }

    private void whichLaneStart()
    {
        
    }

}

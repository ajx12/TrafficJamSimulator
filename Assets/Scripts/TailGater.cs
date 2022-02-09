using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailGater : SimpleCar
{
    //Red Car


    // Start is called before the first frame update
    void Start()
    {
        this.speed = 75;
        Lane1 = mainSpawner.L1List;
        Lane2 = mainSpawner.L2List;
        Lane3 = mainSpawner.L3List;
    }

    // Update is called once per frame
    void Update()
    {
        moveTheCar();
    }

    public override void moveTheCar()
    {
        transform.Translate(userDirection * speed * Time.deltaTime);
        if (transform.position.z > 500)
        {
            Destroy(this.gameObject);
        }
    }

}

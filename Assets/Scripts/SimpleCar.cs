using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleCar : MonoBehaviour
{
    public int speed = 60;
    public Vector3 userDirection = Vector3.forward;
    public string lane = "";
    protected GameObject Lane1;
    protected GameObject Lane2;
    protected GameObject Lane3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTheCar();
        
    }

    public abstract void moveTheCar();
}

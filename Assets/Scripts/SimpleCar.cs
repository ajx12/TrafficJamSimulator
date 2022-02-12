using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleCar : MonoBehaviour
{
    public int speed = 60;
    public Vector3 userDirection = Vector3.forward;
    public bool holdingSomeoneUp = false; //if set to true, try to move to another lane to let the person behind you through
    public ArrayList lane;
    protected ArrayList Lane1;
    protected ArrayList Lane2;
    protected ArrayList Lane3;
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

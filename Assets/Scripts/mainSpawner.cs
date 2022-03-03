using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSpawner : MonoBehaviour
{
    [SerializeField]  GameObject Lane1;
    [SerializeField]  GameObject Lane2;
    [SerializeField]  GameObject Lane3;
    public static GameObject L1;
    public static float maxSpeedL1 = 30;
    public static float maxSpeedL2 = 40;
    public static float maxSpeedL3 = 55;
    public static GameObject L2;
    public static GameObject L3;
    public static ArrayList L1List = new ArrayList();
    public static ArrayList L2List = new ArrayList();
    public static ArrayList L3List = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        L1 = Lane1;
        L2 = Lane2;
        L3 = Lane3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSpawner : MonoBehaviour
{
    [SerializeField]  GameObject Lane1;
    [SerializeField]  GameObject Lane2;
    [SerializeField]  GameObject Lane3;
    public static double sliderMultiplier = 1;
    public static GameObject L1;
    public static GameObject L2;
    public static GameObject L3;
    public static float maxSpeedL1 = 30;
    public static float maxSpeedL2 = 40;
    public static float maxSpeedL3 = 55;
    public static double L1X = -12;
    public static double L2X = -1;
    public static double L3X = 11;
    public static ArrayList L1List = new ArrayList();
    public static ArrayList L2List = new ArrayList();
    public static ArrayList L3List = new ArrayList();
    public static bool L1open = true;
    public static bool L2open = true;
    public static bool L3open = true;
    public static int ln1Br = 5;
    public static int ln1Safe = 75;
    public static int ln1Sun = 95;
    public static int ln1Tg = 100;
    public static int ln2Br = 40;
    public static int ln2Safe = 60;
    public static int ln2Sun = 70;
    public static int ln2Tg = 100;
    public static int ln3Br = 50;
    public static int ln3Safe = 55;
    public static int ln3Sun = 0;
    public static int ln3Tg = 100;


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

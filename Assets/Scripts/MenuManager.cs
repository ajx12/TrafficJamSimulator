using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{


    [SerializeField] GameObject SettingsMenuCanvas;
    [SerializeField] GameObject OpenSettingsBtn;
    [SerializeField] GameObject CloseLane1Btn;
    [SerializeField] GameObject CloseLane2Btn;
    [SerializeField] GameObject CloseLane3Btn;
    [SerializeField] GameObject CloseSettingsBtn;
    [SerializeField] GameObject ApplySettingsBtn;
    [SerializeField] GameObject BrTBLn1;
    [SerializeField] GameObject SafeTBLn1;
    [SerializeField] GameObject SunTBLn1;
    [SerializeField] GameObject TgTBLn1;
    [SerializeField] GameObject BrTBLn2;
    [SerializeField] GameObject SafeTBLn2;
    [SerializeField] GameObject SunTBLn2;
    [SerializeField] GameObject TgTBLn2;
    [SerializeField] GameObject BrTBLn3;
    [SerializeField] GameObject SafeTBLn3;
    [SerializeField] GameObject SunTBLn3;
    [SerializeField] GameObject TgTBLn3;
    [SerializeField] GameObject NumCarSlider;
    [SerializeField] GameObject SpawnPoliceCarBtn;
    [SerializeField] GameObject SpawnAmbulanceBtn;
    TMP_InputField BrChanceL1;
    TMP_InputField SafeChanceL1;
    TMP_InputField SunChanceL1;
    TMP_InputField TgChanceL1;
    TMP_InputField BrChanceL2;
    TMP_InputField SafeChanceL2;
    TMP_InputField SunChanceL2;
    TMP_InputField TgChanceL2;
    TMP_InputField BrChanceL3;
    TMP_InputField SafeChanceL3;
    TMP_InputField SunChanceL3;
    TMP_InputField TgChanceL3;
    ArrayList AllTextBoxes = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        Button Lane1Btn = CloseLane1Btn.GetComponent<Button>();
        Button Lane2Btn = CloseLane2Btn.GetComponent<Button>();
        Button Lane3Btn = CloseLane3Btn.GetComponent<Button>();
        Button SettingsButton = OpenSettingsBtn.GetComponent<Button>();
        SettingsButton.onClick.AddListener(OpenSettings);
        Button ApplyButton = ApplySettingsBtn.GetComponent<Button>();
        ApplyButton.onClick.AddListener(ApplySettings);
        Button SpwnPol = SpawnPoliceCarBtn.GetComponent<Button>(); //Spawns a Police Car
        SpwnPol.onClick.AddListener(SpawnPoliceCar);
        Button SpwnAmb = SpawnAmbulanceBtn.GetComponent<Button>();
        SpwnAmb.onClick.AddListener(SpawnAmbulance);
        Button CloseSettingsButton = CloseSettingsBtn.GetComponent<Button>();
        CloseSettingsButton.onClick.AddListener(CloseSettings);
        BrChanceL1 = BrTBLn1.GetComponent<TMP_InputField>();
        AllTextBoxes.Add(BrChanceL1);
        SafeChanceL1 = SafeTBLn1.GetComponent<TMP_InputField>();
        AllTextBoxes.Add(SafeChanceL1);
        SunChanceL1 = SunTBLn1.GetComponent<TMP_InputField>();
        AllTextBoxes.Add(SunChanceL1);
        TgChanceL1 = TgTBLn1.GetComponent<TMP_InputField>();
        AllTextBoxes.Add(TgChanceL1);
        BrChanceL2 = BrTBLn2.GetComponent<TMP_InputField>();
        AllTextBoxes.Add(BrChanceL2);
        SafeChanceL2 = SafeTBLn2.GetComponent<TMP_InputField>();
        AllTextBoxes.Add(SafeChanceL2);
        SunChanceL2 = SunTBLn2.GetComponent<TMP_InputField>();
        AllTextBoxes.Add(SunChanceL2);
        TgChanceL2 = TgTBLn2.GetComponent<TMP_InputField>();
        AllTextBoxes.Add(TgChanceL2);
        BrChanceL3 = BrTBLn3.GetComponent<TMP_InputField>();
        AllTextBoxes.Add(BrChanceL3);
        SafeChanceL3 = SafeTBLn3.GetComponent<TMP_InputField>();
        AllTextBoxes.Add(SafeChanceL3);
        SunChanceL3 = SunTBLn3.GetComponent<TMP_InputField>();
        AllTextBoxes.Add(SunChanceL3);
        TgChanceL3 = TgTBLn3.GetComponent<TMP_InputField>();
        AllTextBoxes.Add(TgChanceL3);
        print(AllTextBoxes[3]);
        Lane1Btn.onClick.AddListener(CloseLane1);
        Lane2Btn.onClick.AddListener(CloseLane2);
        Lane3Btn.onClick.AddListener(CloseLane3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseLane1()
    {
        bool condition = mainSpawner.L1open;
        bool l3open = mainSpawner.L3open;
        bool l2open = mainSpawner.L2open;
        if (condition == true && (l3open == true || l2open == true))
        {
            mainSpawner.L1open = false;
        }
        else
        {
            mainSpawner.L1open = true;
        }

    }
    void CloseLane2()
    {
        bool condition = mainSpawner.L2open;
        bool l3open = mainSpawner.L3open;
        bool l1open = mainSpawner.L1open;
        if (condition == true && (l3open == true || l1open == true))
        {
            mainSpawner.L2open = false;
        }
        else
        {
            mainSpawner.L2open = true;
        }
    }
    void CloseLane3()
    {
        bool condition = mainSpawner.L3open;
        bool l2open = mainSpawner.L2open;
        bool l1open = mainSpawner.L1open;
        if (condition == true && (l2open == true || l1open == true))
        {
            mainSpawner.L3open = false;
        }
        else
        {
            mainSpawner.L3open = true;
        }
    }

    void OpenSettings()
    {
        SettingsMenuCanvas.SetActive(true);
        CloseLane1Btn.SetActive(false);
        CloseLane2Btn.SetActive(false);
        CloseLane3Btn.SetActive(false);
    }
    void CloseSettings()
    {
        SettingsMenuCanvas.SetActive(false);
        CloseLane1Btn.SetActive(true);
        CloseLane2Btn.SetActive(true);
        CloseLane3Btn.SetActive(true);
    }

    void SpawnPoliceCar()
    {
        mainSpawner.policeNeedSpawning = true;
    }

    void SpawnAmbulance()
    {
        if (mainSpawner.isAmbulance2 == false)
        {
            mainSpawner.ambulanceNeedSpawning = true;
        }
    }

    void ApplySettings()
    {
        int[,] TextBoxesContent = new int[3, 4];
        bool invalid = false;
        int count = 0;
        int laneTotal;
        for (int i = 0; i < 3; i++){
            laneTotal = 0;
            for (int j = 0; j < 4; j++)
            {
                TMP_InputField x = (TMP_InputField)AllTextBoxes[count];
                string text = x.text;
                if (text.Contains("-") == true)
                {
                    invalid = true;
                    break;
                }
                int convertedNumber = int.Parse(text);
                if(convertedNumber != 0)
                {
                    TextBoxesContent[i, j] = convertedNumber + laneTotal;
                }
                else
                {
                    TextBoxesContent[i, j] = 0;
                }
                laneTotal += convertedNumber;
                count++;
            }
            if(laneTotal != 100)
            {
                invalid = true;
                break;
            }
        }

        if(invalid == false)
        {
            mainSpawner.ln1Br = TextBoxesContent[0, 0];
            mainSpawner.ln1Safe = TextBoxesContent[0, 1];
            mainSpawner.ln1Sun = TextBoxesContent[0, 2];
            mainSpawner.ln1Tg = TextBoxesContent[0, 3];
            mainSpawner.ln2Br = TextBoxesContent[1, 0];
            mainSpawner.ln2Safe = TextBoxesContent[1, 1];
            mainSpawner.ln2Sun = TextBoxesContent[1, 2];
            mainSpawner.ln2Tg = TextBoxesContent[1, 3];
            mainSpawner.ln3Br = TextBoxesContent[2, 0];
            mainSpawner.ln3Safe = TextBoxesContent[2, 1];
            mainSpawner.ln3Sun = TextBoxesContent[2, 2];
            mainSpawner.ln3Tg = TextBoxesContent[2, 3];
            Slider numOfCars = NumCarSlider.GetComponent<Slider>();
            double valueOfSlider = numOfCars.value;
            mainSpawner.sliderMultiplier = valueOfSlider;
        }
        //string x = BrChanceL1.text;
    }

}

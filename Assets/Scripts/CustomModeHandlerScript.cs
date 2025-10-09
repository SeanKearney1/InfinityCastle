using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/*
 
    This script harvests the custom presets from the custom game modes
    page, and also refills that page when reloaded.
 
 
 */

public class CustomModeHandlerScript : MonoBehaviour
{

    private int float_settings_max = 22;
    private int bool_settings_max = 6;

    public GameObject[] CustomOptions;
    private GameObject Muzan;


    public void FillCustomData()
    {
        if (Muzan.IsUnityNull()) { Muzan = GameObject.Find("GameManager"); }
        if (Muzan.IsUnityNull()) { return; }

        CustomOptions[0].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getPillarWeight();
        CustomOptions[1].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getPillarSpeed();
        CustomOptions[2].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getBuildingWeight();
        CustomOptions[3].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getBuildingSpeed();
        CustomOptions[4].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getDemonWeight();
        CustomOptions[5].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getDemonSpeed();
        CustomOptions[6].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getYellowCoinWeight();
        CustomOptions[7].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getYellowCoinSpeed();
        CustomOptions[8].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getRareCoinWeight();
        CustomOptions[9].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getRareCoinSpeed();
        CustomOptions[10].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getDashCoinWeight();
        CustomOptions[11].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getDashCoinSpeed();
        CustomOptions[12].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getEnemySpawnRate().x;
        CustomOptions[13].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getEnemySpawnRate().y;
        CustomOptions[14].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getCoinSpawnRate().x;
        CustomOptions[15].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getCoinSpawnRate().y;

        CustomOptions[16].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getMaxPillars();
        CustomOptions[17].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getMaxBuildings();
        CustomOptions[18].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getMaxDemons();
        CustomOptions[19].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getMaxYellowCoins();
        CustomOptions[20].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getMaxRareCoins();
        CustomOptions[21].GetComponent<TMP_InputField>().text = "" + Muzan.GetComponent<Muzan>().customGameSettings.getMaxDashCoins();

        CustomOptions[22].GetComponent<Toggle>().isOn = Muzan.GetComponent<Muzan>().customGameSettings.getIsOneLife();
        CustomOptions[23].GetComponent<Toggle>().isOn = Muzan.GetComponent<Muzan>().customGameSettings.getCanAttackSword();
        CustomOptions[24].GetComponent<Toggle>().isOn = Muzan.GetComponent<Muzan>().customGameSettings.getCanAttackDash();
        CustomOptions[25].GetComponent<Toggle>().isOn = Muzan.GetComponent<Muzan>().customGameSettings.getSinglePlayer();
        CustomOptions[26].GetComponent<Toggle>().isOn = Muzan.GetComponent<Muzan>().customGameSettings.getFriendlyFire();
        CustomOptions[27].GetComponent<Toggle>().isOn = Muzan.GetComponent<Muzan>().customGameSettings.getTimerAddScore();


    }


    public void HarvestCustomData()
    {
        if (Muzan.IsUnityNull()) { Muzan = GameObject.Find("GameManager"); }
        if (Muzan.IsUnityNull()) { return; }

        float[] float_settings = new CustomGameSettings().getFloatDefaults();
        bool[] bool_settings = new CustomGameSettings().getBoolDefaults();



        for (int i = 0; i < float_settings_max; i++)
        {
            Debug.Log(CustomOptions[i] + " " + i);
            if (CustomOptions[i].GetComponent<TMP_InputField>().text != "")
            {
                float_settings[i] = float.Parse(CustomOptions[i].GetComponent<TMP_InputField>().text);
            }
            Debug.Log(float_settings[i]);
        }
        for (int i = 0; i < bool_settings_max; i++)
        {
            bool_settings[i] = CustomOptions[i + float_settings_max].GetComponent<Toggle>().isOn;
            Debug.Log(bool_settings[i]);
        }


        Muzan.GetComponent<Muzan>().customGameSettings = new CustomGameSettings(float_settings, bool_settings);

    }
    


}

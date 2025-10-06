using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


/*
 
 This is a custom class that holds data on any data the player can change
for gamemodes.

    There is two types of data in this class, floats and bools. (ints where redundant)

    instead of two sets of arrays or array lists, I opted for invidual variables
    with each having a getter function.

     I did this because Muzan.getcomponent<Muzan>().customsettings.floats[57382] 
    is a nightmare, and Muzan.getcomponent<Muzan>().customsettings.getPillarWeight()
    is a lot more understandable, and though more time consuming, is better for cleaner 
    code, and no misunderstandings in other files. Also if I add something in the middle 
    everything would break, and we don't program like PirateSoftware here.
 
 
    There is a list of default float and bool values though, this is so null variables
    in custom mode do noot keep values from previous game modes.
 
 */



public class CustomGameSettings
{

    //   This is probably not the best way to handle this 
    // but I got a lot of variables of different types going
    // to a lot of different places.




    private float PillarWeight;
    private float PillarSpeed;
    private float BuildingWeight;
    private float BuildingSpeed;
    private float DemonWeight;
    private float DemonSpeed;
    private float YellowCoinWeight;
    private float YellowCoinSpeed;
    private float RareCoinWeight;
    private float RareCoinSpeed;
    private float DashCoinWeight;
    private float DashCoinSpeed;
    private float EnemySpawnRateMin;
    private float EnemySpawnRateMax;
    private float CoinSpawnRateMin;
    private float CoinSpawnRateMax;
    private int MaxPillars;
    private int MaxBuildings;
    private int MaxDemons;
    private int MaxYellowCoins;
    private int MaxRareCoins;
    private int MaxDashCoins;
    private bool OneLife;
    private bool CanAttackSword;
    private bool CanAttackDash;
    private bool Singleplayer;
    private bool FriendlyFire;

    private float[] default_floats = {
        25.0f,          // PillarWeight
        75.0f,          // PillarSpeed
        55.0f,          // BuildingWeight
        25.0f,          // BuildingSpeed
        20.0f,          // DemonWeight
        1.0f,           // DemonSpeed
        50.0f,          // YellowCoinWeight
        50.0f,          // YellowCoinSpeed
        10.0f,          // RareCoinWeight
        35.0f,          // RareCoinSpeed
        40.0f,          // DashCoinWeight
        30.0f,          // DashCoinSpeed
        1.0f,           // EnemySpawnRateMin
        2.0f,           // EnemySpawnRateMax
        0.0f,           // CoinSpawnRateMin
        1.0f,           // CoinSpawnRateMax
        20.0f,          // MaxPillars
        20.0f,          // MaxBuildings
        20.0f,          // MaxDemons
        20.0f,          // MaxYellowCoins
        20.0f,          // MaxRareCoins
        20.0f,          // MaxDashCoins
    };

    private bool[] default_bools = {
        false,      // Players share life
        true,       // Can use sword
        true,       // Can use dash
        false,      // Singleplayer
        false       // Friendly Fire
    };



    public CustomGameSettings()
    {
        PillarWeight = default_floats[0];
        PillarSpeed = default_floats[1];

        BuildingWeight = default_floats[2];
        BuildingSpeed = default_floats[3];

        DemonWeight = default_floats[4];
        DemonSpeed = default_floats[5];

        YellowCoinWeight = default_floats[6];
        YellowCoinSpeed = default_floats[7];

        RareCoinWeight = default_floats[8];
        RareCoinSpeed = default_floats[9];

        DashCoinWeight = default_floats[10];
        DashCoinSpeed = default_floats[11];

        EnemySpawnRateMin = default_floats[12];
        EnemySpawnRateMax = default_floats[13];

        CoinSpawnRateMin = default_floats[14];
        CoinSpawnRateMax = default_floats[15];

        MaxPillars = (int)default_floats[16];
        MaxBuildings = (int)default_floats[17];
        MaxDemons = (int)default_floats[18];
        MaxYellowCoins = (int)default_floats[19];
        MaxRareCoins = (int)default_floats[20];
        MaxDashCoins = (int)default_floats[21];

        OneLife = default_bools[0];
        CanAttackSword = default_bools[1];
        CanAttackDash = default_bools[2];
        Singleplayer = default_bools[3];
        FriendlyFire = default_bools[4];
    }
    public CustomGameSettings(float[] float_settings, bool[] bool_settings)
    {
        PillarWeight = float_settings[0];
        PillarSpeed = float_settings[1];

        BuildingWeight = float_settings[2];
        BuildingSpeed = float_settings[3];

        DemonWeight = float_settings[4];
        DemonSpeed = float_settings[5];

        YellowCoinWeight = float_settings[6];
        YellowCoinSpeed = float_settings[7];

        RareCoinWeight = float_settings[8];
        RareCoinSpeed = float_settings[9];

        DashCoinWeight = float_settings[10];
        DashCoinSpeed = float_settings[11];

        EnemySpawnRateMin = float_settings[12];
        EnemySpawnRateMax = float_settings[13];

        CoinSpawnRateMin = float_settings[14];
        CoinSpawnRateMax = float_settings[15];

        MaxPillars = (int)float_settings[16];
        MaxBuildings = (int)float_settings[17];
        MaxDemons = (int)float_settings[18];
        MaxYellowCoins = (int)float_settings[19];
        MaxRareCoins = (int)float_settings[20];
        MaxDashCoins = (int)float_settings[21];

        OneLife = bool_settings[0];
        CanAttackSword = bool_settings[1];
        CanAttackDash = bool_settings[2];
        Singleplayer = bool_settings[3];
        FriendlyFire = bool_settings[4];
    }



    public float getPillarWeight() { return PillarWeight; }
    public float getPillarSpeed() { return PillarSpeed; }
    public float getBuildingWeight() { return BuildingWeight; }
    public float getBuildingSpeed() { return BuildingSpeed; }
    public float getDemonWeight() { return DemonWeight; }
    public float getDemonSpeed() { return DemonSpeed; }
    public float getYellowCoinWeight() { return YellowCoinWeight; }
    public float getYellowCoinSpeed() { return YellowCoinSpeed; }
    public float getRareCoinWeight() { return RareCoinWeight; }
    public float getRareCoinSpeed() { return RareCoinSpeed; }
    public float getDashCoinWeight() { return DashCoinWeight; }
    public float getDashCoinSpeed() { return DashCoinSpeed; }
    public Vector2 getEnemySpawnRate() { return new Vector2(EnemySpawnRateMin, EnemySpawnRateMax); }
    public Vector2 getCoinSpawnRate() { return new Vector2(CoinSpawnRateMin, CoinSpawnRateMax); }
    public int getMaxPillars() { return MaxPillars; }
    public int getMaxBuildings() { return MaxBuildings; }
    public int getMaxDemons() { return MaxDemons; }
    public int getMaxYellowCoins() { return MaxYellowCoins; }
    public int getMaxRareCoins() { return MaxRareCoins; }
    public int getMaxDashCoins() { return MaxDashCoins; }
    public bool getIsOneLife() { return OneLife; }
    public bool getCanAttackSword() { return CanAttackSword; }
    public bool getCanAttackDash() { return CanAttackDash; }
    public bool getSinglePlayer() { return Singleplayer; }
    public bool getFriendlyFire() { return FriendlyFire; }


    public float[] getFloatDefaults()
    {
        return default_floats;
    }
    public bool[] getBoolDefaults()
    {
        return default_bools;
    }
}

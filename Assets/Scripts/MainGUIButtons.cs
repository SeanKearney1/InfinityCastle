using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using Unity.Mathematics;

public class MainGUIButtons : MonoBehaviour
{
    public GameObject MainMenuMainPanel;
    public GameObject InGameMainPanel;
    public GameObject GameOverMainPanel;
    public GameObject HighscorePanel;
    public GameObject StatsPanel;
    public GameObject GameModePanel;
    public GameObject CustomModePanel;
    public GameObject PauseDarkness;
    public GameObject Player1HighScoreText;
    public GameObject Player2HighScoreText;

    public GameObject Player1Stats;
    public GameObject Player2Stats;

    public GameObject Player1TotalStats;
    public GameObject Player2TotalStats;

    private GameObject Muzan;
    private bool gamePaused = false;
    public int GameScene;



    private float[][] float_preset_gamemodes = {

        new float[]{ // Coin Race
            40.0f,          // PillarWeight
            75.0f,          // PillarSpeed
            60.0f,          // BuildingWeight
            40.0f,          // BuildingSpeed
            0.0f,           // DemonWeight
            0.0f,           // DemonSpeed
            90.0f,          // YellowCoinWeight
            40.0f,          // YellowCoinSpeed
            10.0f,          // RareCoinWeight
            30.0f,          // RareCoinSpeed
            0.0f,           // DashCoinWeight
            0.0f,           // DashCoinSpeed
            0.5f,           // EnemySpawnRateMin
            1.5f,           // EnemySpawnRateMax
            0.0f,           // CoinSpawnRateMin
            0.75f,          // CoinSpawnRateMax
            3.0f,           // MaxPillars
            20.0f,          // MaxBuildings
            0.0f,           // MaxDemons
            20.0f,          // MaxYellowCoins
            20.0f,          // MaxRareCoins
            0.0f,           // MaxDashCoins
        },
        new float[]{ // Alone
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
        },
        new float[]{ // Demon Slayer
            25.0f,          // PillarWeight
            150.0f,         // PillarSpeed
            25.0f,          // BuildingWeight
            50.0f,          // BuildingSpeed
            50.0f,          // DemonWeight
            1.5f,           // DemonSpeed
            70.0f,          // YellowCoinWeight
            55.0f,          // YellowCoinSpeed
            10.0f,          // RareCoinWeight
            40.0f,          // RareCoinSpeed
            20.0f,          // DashCoinWeight
            35.0f,          // DashCoinSpeed
            0.75f,          // EnemySpawnRateMin
            1.5f,           // EnemySpawnRateMax
            0.0f,           // CoinSpawnRateMin
            1.0f,           // CoinSpawnRateMax
            20.0f,          // MaxPillars
            20.0f,          // MaxBuildings
            20.0f,          // MaxDemons
            20.0f,          // MaxYellowCoins
            20.0f,          // MaxRareCoins
            20.0f,          // MaxDashCoins
        }

    };

    private bool[][] bool_preset_gamemodes = {
        new bool[]{ // Coin Race
            false,      // Players share life
            false,       // Can use sword
            false,       // Can use dash
            false,      // Singleplayer
            false       // Friendly Fire
        },
        new bool[]{  // Alone
            false,      // Players share life
            true,       // Can use sword
            true,       // Can use dash
            true,      // Singleplayer
            false       // Friendly Fire
        },
        new bool[]{ // Demon Slayer
            true,      // Players share life
            true,       // Can use sword
            true,       // Can use dash
            false,      // Singleplayer
            true       // Friendly Fire
        }
    };





    void Start()
    {
        Muzan = GameObject.Find("GameManager");
        MainMenuMainPanel.SetActive(false);
        InGameMainPanel.SetActive(false);
        GameOverMainPanel.SetActive(false);
        HighscorePanel.SetActive(false);
        StatsPanel.SetActive(false);
        PauseDarkness.SetActive(false);
        GameModePanel.SetActive(false);
        CustomModePanel.SetActive(false);
        if (GameScene == 0)
        {
            MainMenuMainPanel.SetActive(true);
        }
        else if (GameScene == 2)
        {
            GameOverMainPanel.SetActive(true);
        }
    }
    void Update()
    {
        showPauseMenu();
    }
    public void Play()
    {

        SceneManager.LoadScene("GameScene");
    }

    public void Resume()
    {
        MainMenuMainPanel.SetActive(false);
        InGameMainPanel.SetActive(false);
        GameOverMainPanel.SetActive(false);
        HighscorePanel.SetActive(false);
        PauseDarkness.SetActive(false);
        StatsPanel.SetActive(false);
        Time.timeScale = 1.0f;
        gamePaused = false;
    }
    private void showPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameScene == 1)
        {
            if (!gamePaused)
            {
                MainMenuMainPanel.SetActive(false);
                InGameMainPanel.SetActive(true);
                GameOverMainPanel.SetActive(false);
                PauseDarkness.SetActive(true);
                StatsPanel.SetActive(false);
                Time.timeScale = 0.0f;
                gamePaused = true;
            }
            else
            {
                MainMenuMainPanel.SetActive(false);
                InGameMainPanel.SetActive(false);
                GameOverMainPanel.SetActive(false);
                HighscorePanel.SetActive(false);
                PauseDarkness.SetActive(false);
                StatsPanel.SetActive(false);
                Time.timeScale = 1.0f;
                gamePaused = false;
            }
        }
    }

    public void MuzanArrives() // for when game manager isn't initialized yet on the title screen.
    {
        Muzan = GameObject.Find("GameManager");
    }



    public void Exit()
    {
        Application.Quit();
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("TitleScene");
        Muzan.GetComponent<Muzan>().LeaveTheCastle();
        Time.timeScale = 1.0f;
    }

    public void HighScores()
    {
        MainMenuMainPanel.SetActive(false);
        InGameMainPanel.SetActive(false);
        GameOverMainPanel.SetActive(false);
        HighscorePanel.SetActive(true);
        if (GameScene != 1)
        {
            PauseDarkness.SetActive(false);
        }
        StatsPanel.SetActive(false);
        Player1HighScoreText.GetComponent<HighScoreDisplayScript>().UpdateHighScores();
        Player2HighScoreText.GetComponent<HighScoreDisplayScript>().UpdateHighScores();
    }
    public void BackToMain()
    {
        if (GameScene == 0)
        {
            MainMenuMainPanel.SetActive(true);
        }
        else if (GameScene == 1)
        {
            InGameMainPanel.SetActive(true);
        }
        else if (GameScene == 2)
        {
            GameOverMainPanel.SetActive(true);
        }
        HighscorePanel.SetActive(false);
        if (GameScene != 1)
        {
            PauseDarkness.SetActive(false);
        }
        StatsPanel.SetActive(false);
        GameModePanel.SetActive(false);
        CustomModePanel.SetActive(false);
    }

    public void GameModesPage()
    {
        GameModePanel.SetActive(true);
        CustomModePanel.SetActive(false);
        MainMenuMainPanel.SetActive(false);
        InGameMainPanel.SetActive(false);
        GameOverMainPanel.SetActive(false);
        PauseDarkness.SetActive(true);
    }

    public void CustomModePage()
    {
        GameModePanel.SetActive(false);
        CustomModePanel.SetActive(true);
        MainMenuMainPanel.SetActive(false);
        InGameMainPanel.SetActive(false);
        GameOverMainPanel.SetActive(false);

        gameObject.GetComponentInChildren<CustomModeHandlerScript>().FillCustomData();
    }

    public void BackToGameMode()
    {
        gameObject.GetComponentInChildren<CustomModeHandlerScript>().HarvestCustomData();
        GameModesPage();
    }

    public void StartPresetGameMode(int index)
    {
        if (index == -1) // custom game mode.
        {
            gameObject.GetComponentInChildren<CustomModeHandlerScript>().HarvestCustomData();
        }
        else
        {
            Debug.Log(Muzan);
            Muzan.GetComponent<Muzan>().customGameSettings = new CustomGameSettings(float_preset_gamemodes[index], bool_preset_gamemodes[index]);
        }


        Play();

    }

    public void Stats()
    {
        MainMenuMainPanel.SetActive(false);
        InGameMainPanel.SetActive(false);
        GameOverMainPanel.SetActive(false);
        HighscorePanel.SetActive(false);
        PauseDarkness.SetActive(true);
        StatsPanel.SetActive(true);

        FillStats();
    }


    private void FillStats()
    {
        if (Muzan.IsUnityNull())
        {
            Muzan = GameObject.Find("GameManager");
        }
        if (Muzan.IsUnityNull()) { return; }

        Player1Stats.GetComponent<TextMeshProUGUI>().text = Muzan.GetComponent<Muzan>().getStringPlayerStats(0);
        Player2Stats.GetComponent<TextMeshProUGUI>().text = Muzan.GetComponent<Muzan>().getStringPlayerStats(1);
        Player1TotalStats.GetComponent<TextMeshProUGUI>().text = Muzan.GetComponent<Muzan>().getStringPlayerTotalStats(0);
        Player2TotalStats.GetComponent<TextMeshProUGUI>().text = Muzan.GetComponent<Muzan>().getStringPlayerTotalStats(1);
    }

}


using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


/*
 
 This script belongs to "Spawners" and is the brain
    behind all the spawning of enemies and coins/

    This script tells the other spawners when and what to spawn,
    managing custom cooldowns, max counts (not for coins) and what
    enemies to spawn given their weights.
 
 
 */



public class Nakime : MonoBehaviour
{
    private int[] SpawnWeights = { 20, 25, 55 }; // Demon, Pillar, Building.
    private float InitialCooldown = 4.0f;
    private float AttackCooldown;
    private Vector2 AttackCooldownMinMax;
    private Vector2 CoinCooldownMinMax;
    private double timeStamp_Attack = 0.0;
    private double time_stamp_Coin = 0.0;
    private float CoinCooldown;

    private int MaxPillars;
    private int current_pillars;
    private int MaxBuildings;
    private int current_buildings;
    private int MaxDemons;
    private int current_demons;
    public GameObject DemonSpawner;
    public GameObject PillarSpawner;
    public GameObject BuildingSpawner;
    public GameObject Tanjiro;
    public GameObject Giyu;
    public GameObject Muzan;

    public GameObject CoinSpawner;


    private double GameTime;

    void Start()
    {
        GameTime = 0;

        Muzan = GameObject.Find("GameManager");
        if (!Muzan.IsUnityNull())
        {
            Muzan.GetComponent<Muzan>().NewRun();
            Muzan.GetComponent<Muzan>().IntoTheInfinityCastle();
            Muzan.GetComponent<Muzan>().Tanjiro = Tanjiro;
            Muzan.GetComponent<Muzan>().Giyu = Giyu;
            AttackCooldownMinMax = Muzan.GetComponent<Muzan>().customGameSettings.getEnemySpawnRate();
            CoinCooldownMinMax = Muzan.GetComponent<Muzan>().customGameSettings.getCoinSpawnRate();
            SpawnWeights[0] = (int)Muzan.GetComponent<Muzan>().customGameSettings.getDemonWeight();
            SpawnWeights[1] = (int)Muzan.GetComponent<Muzan>().customGameSettings.getPillarWeight();
            SpawnWeights[2] = (int)Muzan.GetComponent<Muzan>().customGameSettings.getBuildingWeight();

            MaxPillars = Muzan.GetComponent<Muzan>().customGameSettings.getMaxPillars();
            MaxBuildings = Muzan.GetComponent<Muzan>().customGameSettings.getMaxBuildings();
            MaxDemons = Muzan.GetComponent<Muzan>().customGameSettings.getMaxDemons();

            if (Muzan.GetComponent<Muzan>().customGameSettings.getSinglePlayer()) {
                Destroy(Giyu);
            }
        }

    }



    void Update()
    {
        GameTime += Time.deltaTime;

        if (InitialCooldown > GameTime) { return; }

        if (timeStamp_Attack + AttackCooldown < GameTime)
        {
            int Attack = DecideAttack();
            AttackCooldown = Random.Range(AttackCooldownMinMax.x, AttackCooldownMinMax.y);
            timeStamp_Attack = GameTime;

            if (Attack == 0 && current_demons < MaxDemons)
            {
                DemonSpawner.GetComponent<DemonSpawnerScript>().SpawnDemon();
                current_demons++;
            }
            else if (Attack == 1 && current_pillars < MaxPillars)
            {
                PillarSpawner.GetComponent<PillarSpawnerScript>().SpawnPillar();
                current_pillars++;
            }
            else if (Attack == 2 && current_buildings < MaxBuildings)
            {
                BuildingSpawner.GetComponent<BuildingSpawnerScript>().SpawnBuilding();
                current_buildings++;
            }
        }

        if (time_stamp_Coin + CoinCooldown < GameTime)
        {
            time_stamp_Coin = GameTime;
            CoinCooldown = Random.Range(CoinCooldownMinMax.x, CoinCooldownMinMax.y);
            CoinSpawner.GetComponent<CoinSpawnerScript>().SpawnCoin();
        }
    }




    private int DecideAttack()
    {
        int random_choice = Random.Range(0, SpawnWeights.Sum());
        float the_summererer = 0.0f;

        for (int i = 0; i < SpawnWeights.Length; i++)
        {
            the_summererer += SpawnWeights[i];
            if (random_choice <= the_summererer)
            {
                return i;
            }
        }
        return 0;
    }



    public void KilledPillar() { current_pillars--; }
    public void KilledBuilding() { current_buildings--; }
    public void KilledDemon() { current_demons--; }

}

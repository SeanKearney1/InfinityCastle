
using UnityEngine;

public class Nakime : MonoBehaviour
{
    public float AttackCooldown;
    public float DemonCooldown;
    public float PillarCooldown;
    public float BuildingCooldown;
    private double timeStamp_Attack = 0.0;
    private double timeStamp_Demon = 0.0;
    private double timeStamp_Pillar = 0.0;
    private double timeStamp_Building = 0.0;
    public GameObject DemonSpawner;
    public GameObject PillarSpawner;
    public GameObject BuildingSpawner;

    public GameObject CoinSpawner;

    private double GameTime;

    void Start()
    {
        GameTime = 0;
    }



    void Update()
    {

        //Debug.Log("GameTime: " + GameTime);

        GameTime += Time.deltaTime;

        if (timeStamp_Attack + AttackCooldown < GameTime)
        {
            int Attack = Random.Range(0, 3);
            timeStamp_Attack = GameTime;

            if (Attack == 0 && timeStamp_Demon + DemonCooldown < GameTime)
            {
                DemonSpawner.GetComponent<DemonSpawnerScript>().SpawnDemon();
                timeStamp_Demon = GameTime;
            }
            if (Attack == 1 && timeStamp_Pillar + PillarCooldown < GameTime)
            {
                PillarSpawner.GetComponent<PillarSpawnerScript>().SpawnPillar();
                timeStamp_Pillar = GameTime;
            }
            if (Attack == 2 && timeStamp_Building + BuildingCooldown < GameTime)
            {
                BuildingSpawner.GetComponent<BuildingSpawnerScript>().SpawnBuilding();
                timeStamp_Building = GameTime;
            }

            CoinSpawner.GetComponent<CoinSpawnerScript>().SpawnCoin();
        }
    }

}

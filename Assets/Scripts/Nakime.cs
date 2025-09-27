
using UnityEngine;

public class Nakime : MonoBehaviour
{
    public float AttackCooldown;
    public float DemonCooldown;
    public float PillarCooldown;
    public float BuildingCooldown;
    private float timeStamp_Attack = 0.0f;
    private float timeStamp_Demon = 0.0f;
    private float timeStamp_Pillar = 0.0f;
    private float timeStamp_Building = 0.0f;
    public GameObject DemonSpawner;
    public GameObject PillarSpawner;
    public GameObject BuildingSpawner;

    void Start()
    {
        //CurrentAttackCooldown = AttackCooldown;
    }



    void Update()
    {

        if (timeStamp_Attack + AttackCooldown < Time.time) {
            int Attack = Random.Range(0, 3);
            timeStamp_Attack = Time.time;

            if (Attack == 0 && timeStamp_Demon + DemonCooldown < Time.time)
            {
                DemonSpawner.GetComponent<DemonSpawnerScript>().SpawnDemon();
                timeStamp_Demon = Time.time;
            }
            if (Attack == 1 && timeStamp_Pillar + PillarCooldown < Time.time)
            {
                PillarSpawner.GetComponent<PillarSpawnerScript>().SpawnPillar();
                timeStamp_Pillar = Time.time;
            }
            if (Attack == 2 && timeStamp_Building + BuildingCooldown < Time.time)
            {
                BuildingSpawner.GetComponent<BuildingSpawnerScript>().SpawnBuilding();
                timeStamp_Building = Time.time;
            }
        }
    }



}

using UnityEngine;

public class PillarSpawnerScript : MonoBehaviour
{
    public GameObject PillarPrefab;
    public GameObject PillarWarningPrefab;
    public GameObject NoSpawn;
    private float pixel_size;

    public float WarnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pixel_size = PillarPrefab.GetComponent<SpriteRenderer>().size.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPillar()
    {
        GameObject NewPillar = Instantiate(PillarPrefab);
        GameObject NewPillarWarning = Instantiate(PillarWarningPrefab);

        int random_pillar_size = Random.Range(24, 48);

        Vector2 pillar_size = new Vector2(pixel_size * random_pillar_size, pixel_size);

        NewPillar.GetComponent<SpriteRenderer>().size = pillar_size;
        NewPillarWarning.GetComponent<SpriteRenderer>().size = pillar_size;
        NewPillar.GetComponent<BoxCollider2D>().size = pillar_size;

        NewPillar.transform.position = GetPillarSpawn(NewPillar, pillar_size);
        NewPillarWarning.transform.position = new Vector2(0,NewPillar.transform.position.y);

        NewPillar.GetComponent<PillarLogicScript>().SetWarnTime(WarnTime);
        NewPillarWarning.GetComponent<WarningKillMe>().KillTime(WarnTime);


    }


        private Vector2 GetPillarSpawn(GameObject NewPillar, Vector2 pillar_size)
    {
        Vector2 spawn_vec = new Vector2(0, 0);
        Vector2 screen_vec = NoSpawn.GetComponent<BoxCollider2D>().size;
        int random_side = Random.Range(0, 2);


        spawn_vec.y = Random.Range((-1 * screen_vec.y / 2)+(pillar_size.y*5/2), (screen_vec.y/2)-(pillar_size.y*5/2));

        if (random_side == 0)
        {
            spawn_vec.x = (screen_vec.x / 2)+(pillar_size.x*5/2);
            NewPillar.GetComponent<PillarLogicScript>().SetPillarDirection(false);
        }
        else
        {
            spawn_vec.x = (-1 * screen_vec.x / 2)-(pillar_size.x*5/2);
            NewPillar.GetComponent<PillarLogicScript>().SetPillarDirection(true);
        }

        return spawn_vec;
    }

}

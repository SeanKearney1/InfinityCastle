using UnityEngine;

public class DemonSpawnerScript : MonoBehaviour
{
    public GameObject DemonPrefab;
    public GameObject NoSpawn;

    private float MinOffScreenDistance = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnDemon()
    {
        Debug.Log("Demon");
        GameObject NewDemon = Instantiate(DemonPrefab);


        NewDemon.transform.position = GetDemonSpawn();

    }




    private Vector2 GetDemonSpawn()
    {
        Vector2 spawn_vec = new Vector2(0, 0);
        Vector2 screen_vec = NoSpawn.GetComponent<BoxCollider2D>().size;
        int random_side = Random.Range(0, 4);
        if (random_side == 0 || random_side == 2) // north and south
        {
            spawn_vec.x = Random.Range(((-1 * screen_vec.x) + MinOffScreenDistance) / 2, (screen_vec.x + MinOffScreenDistance) / 2);

            if (random_side == 0)
            {
                spawn_vec.y = (screen_vec.y + MinOffScreenDistance) / 2;
            }
            else
            {
                spawn_vec.y = -1 * (screen_vec.y + MinOffScreenDistance) / 2;
            }
        }
        else // east and west
        {

            spawn_vec.y = Random.Range(((-1 * screen_vec.y) + MinOffScreenDistance) / 2, (screen_vec.y + MinOffScreenDistance) / 2);

            if (random_side == 1)
            {
                spawn_vec.x = (screen_vec.x + MinOffScreenDistance) / 2;
            }
            else // 3
            {
                spawn_vec.x = -1 * (screen_vec.x + MinOffScreenDistance) / 2;
            }
        }
        return spawn_vec;
    }


}





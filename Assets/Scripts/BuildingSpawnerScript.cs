using JetBrains.Annotations;
using UnityEngine;

public class BuildingSpawnerScript : MonoBehaviour
{
    public GameObject BuildingPrefab;
    public GameObject BuildingWarningPrefab;
    public GameObject NoSpawn;
    public float WarnTime;

    private float pixel_size;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pixel_size = BuildingPrefab.GetComponent<SpriteRenderer>().size.y;
    }

    public void SpawnBuilding()
    {
        Debug.Log("Building");
        GameObject NewBuilding = Instantiate(BuildingPrefab);
        GameObject NewBuildingWarning = Instantiate(BuildingWarningPrefab);

        NewBuildingWarning.GetComponent<SpriteRenderer>().size = new Vector2(pixel_size,pixel_size*12);

        NewBuilding.transform.position = GetBuildingSpawn();

        NewBuildingWarning.transform.position = new Vector2(NewBuilding.transform.position.x,0);
        
        NewBuilding.GetComponent<BuildingLogicScript>().SetWarnTime(WarnTime);
        NewBuildingWarning.GetComponent<WarningKillMe>().KillTime(WarnTime);

    }


    private Vector2 GetBuildingSpawn()
    {
        Vector2 spawn_vec = new Vector2(0, 0);
        Vector2 screen_vec = NoSpawn.GetComponent<BoxCollider2D>().size;

        spawn_vec.x = Random.Range((-1 * screen_vec.x + pixel_size)/2, (screen_vec.x/2 - pixel_size)/2);
        spawn_vec.y = (-1*screen_vec.y / 2) - pixel_size;


        return spawn_vec;
    }
 
}

using UnityEngine;
using Unity.VisualScripting;
public class BuildingLogicScript : MonoBehaviour
{
    private float MoveSpeed;
    private float WarnTime;
    public int ExpireTime;
    private float time_stamp;
    private Rigidbody2D rb;
    private GameObject[] ParentedObjects = { };
    private GameObject Muzan;
    private GameObject Nakime;



/*
    This script is the brain of each building that flies up past the player.
 
    When it starts it continously moves upward, and if it touches a player,
    it will add that player to it's list and will move that player upwards.

    Along with that it will set the collision layer of the player(s) to be able to go
    through the invisible walls around the map.
 */







    void Start()
    {

        time_stamp = Time.time;
        rb = GetComponent<Rigidbody2D>();
        Muzan = GameObject.Find("GameManager");
        Nakime = GameObject.Find("Spawners");

        if (!Muzan.IsUnityNull())
        {
            MoveSpeed = Muzan.GetComponent<Muzan>().customGameSettings.getBuildingSpeed();
        }
    }
    void Update()
    {
        if (time_stamp + WarnTime < Time.time)
        {
            MoveBuilding();
        }
        if (time_stamp + WarnTime + ExpireTime < Time.time)
        {
            Nakime.GetComponent<Nakime>().KilledBuilding();
            Destroy(this.gameObject);
        }
    }

    private void MoveBuilding()
    {
        rb.linearVelocityY = MoveSpeed;
        MoveChildren();
    }

    public void SetWarnTime(float warn_time)
    {
        WarnTime = warn_time;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 player_pos = collision.gameObject.transform.position;
            Vector3 building_pos = gameObject.transform.position;
            Vector2 building_size = gameObject.GetComponent<BoxCollider2D>().size;

            if (player_pos.y > building_pos.y+building_size.y) {
                collision.gameObject.layer = 7;
                Debug.Log("Grabbed Player   "+collision.gameObject.layer);
                ParentedObjects = AddObjectToArray(ParentedObjects, collision.gameObject);
            }
        }
    }





    private void MoveChildren()
    {
        for (int i = 0; i < ParentedObjects.Length; i++)
        {
            if (ParentedObjects[i].IsUnityNull())
            {
                ParentedObjects = RemoveFromArray(ParentedObjects, i);
                i--;
            }
            else
            {
                ParentedObjects[i].GetComponent<Rigidbody2D>().linearVelocityY = MoveSpeed;
            }
        }
    }
    private GameObject[] AddObjectToArray(GameObject[] array, GameObject add_object)
    {
        GameObject[] new_array = new GameObject[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            new_array[i] = array[i];
        }
        new_array[array.Length] = add_object;
        return new_array;
    }

    private GameObject[] RemoveFromArray(GameObject[] array, int remove_index)
    {
        int HmmWhyIsTheArrayDeletingTheEnd = 0;
        if (array.Length <= 1) { return new GameObject[0]; } // If array is only 1 item, just return a blank array.
        GameObject[] new_array = new GameObject[array.Length - 1];
        for (int i = 0; i < new_array.Length; i++)
        {
            if (i == remove_index)
            {
                HmmWhyIsTheArrayDeletingTheEnd++;
            }
            new_array[i] = array[i + HmmWhyIsTheArrayDeletingTheEnd];
        }
        return new_array;
    }
}

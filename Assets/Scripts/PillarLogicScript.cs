//using NUnit.Framework;
//using UnityEditor.Callbacks;
using Unity.VisualScripting;
using UnityEngine;

public class PillarLogicScript : MonoBehaviour
{

    private float MoveSpeed;
    private bool direction;

    private float WarnTime;

    public int ExpireTime;

    private float time_stamp;

    private Rigidbody2D rb;

    private GameObject[] ParentedObjects = { };

    private GameObject Muzan;
    private GameObject Nakime;

    void Start()
    {
        time_stamp = Time.time;
        rb = GetComponent<Rigidbody2D>();
        Muzan = GameObject.Find("GameManager");
        Nakime = GameObject.Find("Spawners");

        if (!Muzan.IsUnityNull())
        {
            MoveSpeed = Muzan.GetComponent<Muzan>().customGameSettings.getPillarSpeed();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (time_stamp + WarnTime < Time.time)
        {
            MovePillar();
        }
        if (time_stamp + WarnTime + ExpireTime < Time.time)
        {
            Nakime.GetComponent<Nakime>().KilledPillar();
            Destroy(this.gameObject);
        }
    }

    private void MovePillar()
    {
        int dir_multiplier = 1;
        if (direction == false) // TRUE: starts on the left and moves towards the right hand of the screen.
        {
            dir_multiplier = -1;
        }
        rb.linearVelocityX = MoveSpeed * dir_multiplier;
        MoveChildren(dir_multiplier);
    }


    public void SetPillarDirection(bool IsGoingRight)
    {
        direction = IsGoingRight;
    }


    public void SetWarnTime(float warn_time)
    {
        WarnTime = warn_time;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 player_pos = collision.gameObject.transform.position;
            Vector3 pillar_pos = gameObject.transform.position;
            Vector2 pillar_size = gameObject.GetComponent<BoxCollider2D>().size;

            if (!(player_pos.x > pillar_pos.x-pillar_size.x || player_pos.x < pillar_pos.x+pillar_size.x)) {
                collision.gameObject.layer = 7;
                Debug.Log("Grabbed Player   "+collision.gameObject.layer);
                ParentedObjects = AddObjectToArray(ParentedObjects, collision.gameObject);
            }
        }
    }
    


    private void MoveChildren(int dir_multiplier)
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
                ParentedObjects[i].GetComponent<Rigidbody2D>().linearVelocityX = MoveSpeed * dir_multiplier;
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

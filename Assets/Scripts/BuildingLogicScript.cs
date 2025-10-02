using UnityEngine;
using Unity.VisualScripting;
public class BuildingLogicScript : MonoBehaviour
{
    public int MoveSpeed;
    private float WarnTime;
    public int ExpireTime;
    private float time_stamp;
    private Rigidbody2D rb;
    private GameObject[] ParentedObjects = { };
    void Start()
    {
        time_stamp = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time_stamp + WarnTime < Time.time)
        {
            MoveBuilding();
        }
        if (time_stamp + WarnTime + ExpireTime < Time.time)
        {
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
            collision.gameObject.transform.SetParent(this.gameObject.transform);
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
                ParentedObjects[i].GetComponent<Rigidbody2D>().linearVelocityX = MoveSpeed;
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

using Unity.VisualScripting;
using UnityEngine;

public class InitGameManager : MonoBehaviour
{
    public GameObject MuzanPrefab;
    void Start()
    {
        if(GameObject.Find("GameManager").IsUnityNull())
        {
            Instantiate(MuzanPrefab);
        }
    }
}

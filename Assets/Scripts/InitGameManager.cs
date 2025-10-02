using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class InitGameManager : MonoBehaviour
{
    void Start()
    {
        if (GameObject.Find("GameManager").IsUnityNull())
        {
            GameObject Muzan = new GameObject("GameManager");
            Muzan.AddComponent<Muzan>();
        }
    }
}

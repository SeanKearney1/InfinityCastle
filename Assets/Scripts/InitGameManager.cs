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
            GameObject MainGUI = GameObject.Find("MainGUI");
            if (!MainGUI.IsUnityNull())
            {
                MainGUI.GetComponent<MainGUIButtons>().MuzanArrives();
            }
            
        }
    }
}

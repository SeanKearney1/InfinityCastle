using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/*
 This script adds the GameManager on first load.


    It is 10/6/2025 and you are just going over singleton objects.

    Ehhhh if it ain't broke don't fix it. InitGameManager, you get to live.




    For now.
 */


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

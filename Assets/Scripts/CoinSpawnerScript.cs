//using System.Linq;
using UnityEngine;

public class CoinSpawnerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject CoinBasic;
    public GameObject CoinRare;
    public GameObject CoinDash;

    public GameObject NoSpawn;

    private float pixel_size;

    private int[] CoinWeights = { 50, 10, 40 };

    void Start()
    {
        pixel_size = CoinBasic.GetComponent<SpriteRenderer>().size.y;
    }

    public void SpawnCoin()
    {
        int random_choice = Random.Range(0, CoinWeights[0] + CoinWeights[1] + CoinWeights[2]);

        GameObject newCoin;

        if (random_choice <= CoinWeights[0]) // coin basic 
        {
            newCoin = Instantiate(CoinBasic);
        }
        else if (random_choice <= CoinWeights[0] + CoinWeights[1]) // coin rare
        {
            newCoin = Instantiate(CoinRare);
        }
        else // coin dash
        {
            newCoin = Instantiate(CoinDash);
        }


        newCoin.transform.position = SetCoinSpawn();
    }



    private Vector2 SetCoinSpawn()
    {
        Vector2 spawn_vec = new Vector2(0, 0);
        Vector2 screen_vec = NoSpawn.GetComponent<BoxCollider2D>().size;

        spawn_vec.x = Random.Range((-1 * screen_vec.x + pixel_size)/2, (screen_vec.x/2 - pixel_size)/2);
        spawn_vec.y = (-1*screen_vec.y / 2) - pixel_size;

        return spawn_vec;
    }
}

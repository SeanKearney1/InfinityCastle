//using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

/*
    This script handles the spawning of coins when told.
    Spawns randomly on X axis, just below player view.

    Handles the Max count for the 3 coin types.
 
 
 
*/


public class CoinSpawnerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject CoinBasic;
    public GameObject CoinRare;
    public GameObject CoinDash;
    public GameObject NoSpawn;
    private GameObject Muzan;
    private int MaxYellowCoins;
    private int current_yellow_coins;
    private int MaxRareCoins;
    private int current_rare_coins;
    private int MaxDashCoins;
    private int current_dash_coins;
    private float pixel_size;

    private int[] CoinWeights = { 50, 10, 40 };

    void Start()
    {
        pixel_size = CoinBasic.GetComponent<SpriteRenderer>().size.y;
        Muzan = GameObject.Find("GameManager");
        if (!Muzan.IsUnityNull())
        {
            CoinWeights[0] = (int)Muzan.GetComponent<Muzan>().customGameSettings.getYellowCoinWeight();
            CoinWeights[1] = (int)Muzan.GetComponent<Muzan>().customGameSettings.getRareCoinWeight();
            CoinWeights[2] = (int)Muzan.GetComponent<Muzan>().customGameSettings.getDashCoinWeight();

            MaxYellowCoins = Muzan.GetComponent<Muzan>().customGameSettings.getMaxYellowCoins();
            MaxRareCoins = Muzan.GetComponent<Muzan>().customGameSettings.getMaxRareCoins();
            MaxDashCoins = Muzan.GetComponent<Muzan>().customGameSettings.getMaxDashCoins();

            Debug.Log("COINS " + MaxYellowCoins + " " +MaxRareCoins+ " " + MaxDashCoins);
        }
    }

    public void SpawnCoin()
    {
        int random_choice = Random.Range(0, CoinWeights[0] + CoinWeights[1] + CoinWeights[2]);

        GameObject newCoin;

        Debug.Log("COIN COUNTS " + current_yellow_coins + " " +current_rare_coins+ " " + current_dash_coins);

        if (random_choice <= CoinWeights[0] && current_yellow_coins < MaxYellowCoins) // coin basic 
        {
            newCoin = Instantiate(CoinBasic);
            newCoin.GetComponent<CoinScript>().CoinSpawnerScript = this.gameObject;
            newCoin.transform.position = SetCoinSpawn();
            current_yellow_coins++;
        }
        else if (random_choice <= CoinWeights[0] + CoinWeights[1] && current_rare_coins < MaxRareCoins) // coin rare
        {
            newCoin = Instantiate(CoinRare);
            newCoin.GetComponent<CoinScript>().CoinSpawnerScript = this.gameObject;
            newCoin.transform.position = SetCoinSpawn();
            current_rare_coins++;
        }
        else if (current_dash_coins < MaxDashCoins) // coin dash
        {
            newCoin = Instantiate(CoinDash);
            newCoin.GetComponent<CoinScript>().CoinSpawnerScript = this.gameObject;
            newCoin.transform.position = SetCoinSpawn();
            current_dash_coins++;
        }
    }



    private Vector2 SetCoinSpawn()
    {
        Vector2 spawn_vec = new Vector2(0, 0);
        Vector2 screen_vec = NoSpawn.GetComponent<BoxCollider2D>().size;

        spawn_vec.x = Random.Range((-1 * screen_vec.x + pixel_size) / 2, (screen_vec.x - pixel_size) / 2);
        spawn_vec.y = (-1 * screen_vec.y / 2) - pixel_size;

        return spawn_vec;
    }


    public void KilledCoin(int coin_type)
    {
        if      (coin_type == 1) { current_yellow_coins--; }
        else if (coin_type == 2) { current_rare_coins--; }
        else if (coin_type == 3) { current_dash_coins--; }
    }
}

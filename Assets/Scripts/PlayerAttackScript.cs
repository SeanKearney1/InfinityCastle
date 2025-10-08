//using UnityEditor.Toolbars;
using Unity.VisualScripting;
using UnityEngine;

/*
 Handles the attack for a player.

    This is in a seperate script from the player script
    because the "Kill Aura" gamemobject for the player
    is seperate and at the time this seemed easier.

    If I still believe that is up for debate.
 
 */
public class PlayerAttackScript : MonoBehaviour
{
    private double AttackDuration = 0.25;
    private double AttackCooldown = 1.0;
    private bool IsAttacking = false;
    private double Attacking_time_stamp = -9999999.0;
    private double Attack_cooldown_time_stamp = -9999999.0;
    private bool FriendlyFire;
    private GameObject[] ObjectsInKillAura = { };
    private GameObject Muzan;
    private GameObject Nakime;
    private double GameTime = 0;

    private bool CanAttackSword;

    private int PlayerIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerIndex = this.GetComponentInParent<PlayerScript>().PlayerIndex;
        Muzan = GameObject.Find("GameManager");
        Nakime = GameObject.Find("Spawners");

        if (!Muzan.IsUnityNull())
        {
            CanAttackSword = Muzan.GetComponent<Muzan>().customGameSettings.getCanAttackSword();
            FriendlyFire = Muzan.GetComponent<Muzan>().customGameSettings.getFriendlyFire();
        }
    }

    // Update is called once per frame
    void Update()
    {

        GameTime += Time.deltaTime;

        if (CanAttackSword) { Attack(); }
    }

    private void Attack()
    {
        if (Attack_cooldown_time_stamp + AttackCooldown < GameTime)
        {
            if (PlayerIndex == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                Attacking_time_stamp = GameTime;
                Attack_cooldown_time_stamp = GameTime;
                AttackLogic();
            }
            else if (PlayerIndex == 1 && Input.GetKeyDown(KeyCode.RightShift))
            {
                Attacking_time_stamp = GameTime;
                Attack_cooldown_time_stamp = GameTime;
                AttackLogic();
            }
        }
        if (Attacking_time_stamp + AttackDuration >= GameTime)
        {
            IsAttacking = true;
            gameObject.GetComponentInParent<PlayerScript>().AnimateAttacker(IsAttacking);
        }
        else
        {
            IsAttacking = false;
            gameObject.GetComponentInParent<PlayerScript>().AnimateAttacker(IsAttacking);
        } 
    }


    public bool getIsAttacking()
    {
        return IsAttacking;
    }


    private void AttackLogic()
    {
        int attack_dash_index = 5;
        if (!IsAttacking) { attack_dash_index = 6; }

        for (int i = 0; i < ObjectsInKillAura.Length; i++)
        {
            if (ObjectsInKillAura[i].IsUnityNull()) // If the object has died.
            {
                ObjectsInKillAura = RemoveFromArray(ObjectsInKillAura, i);
                i--;
            }
            else
            {
                if (ObjectsInKillAura[i].CompareTag("Demon") || (ObjectsInKillAura[i].CompareTag("Player") && FriendlyFire))
                {
                    if (ObjectsInKillAura[i].CompareTag("Demon") || (ObjectsInKillAura[i].GetComponent<PlayerScript>() && ObjectsInKillAura[i].GetComponent<PlayerScript>().PlayerIndex != PlayerIndex))
                    {

                        if (ObjectsInKillAura[i].CompareTag("Demon"))
                        {
                            Nakime.GetComponent<Nakime>().KilledDemon();
                            Muzan.GetComponent<Muzan>().AddPlayerCurrentRunStat(PlayerIndex, attack_dash_index);
                        }
                        ObjectsInKillAura[i].GetComponent<DemonLogicScript>().Slashed(PlayerIndex);
                        ObjectsInKillAura = RemoveFromArray(ObjectsInKillAura, i);
                        i--;
                    }
                }
            }
        }
    }



    //    This overly complicated mess is due to me not wanting to use "OnTriggerStay2D",
    //which would be running every frame, so instead it keeps track of all objects within
    //it's trigger, then acts on them when needed. the attack logic for dashing was rooted
    //through here because I wasn't copy-pasting all this.
    //
    //    So yeah if a demon was already within the player's kill aura, it wouldn't be picked up,
    //resulting in close calls and quick reaction times of players being punished for already
    //being too close. Future increasing of the players attack radius would only worsen this
    //problem, ironically making it more difficult to play.
    public void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectsInKillAura = AddObjectToArray(ObjectsInKillAura, collision.gameObject); // Adds newest collision.

        if (IsAttacking || GetComponentInParent<PlayerScript>().IsPlayerDashing())
        {
            AttackLogic();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < ObjectsInKillAura.Length; i++)
        {
            if (collision.gameObject == ObjectsInKillAura[i])
            {
                ObjectsInKillAura = RemoveFromArray(ObjectsInKillAura, i);
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

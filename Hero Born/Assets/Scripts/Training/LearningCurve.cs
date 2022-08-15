using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    public bool weaponEquipped = true;
    public bool pureOfHeart = true;
    public bool hasSecretIncantation = false;

    public string rareItem = "Brilliant";
    public string weaponType = "Longsword";

    private Transform cameraTransform;
    public GameObject directionalLight;
    private Transform lightTransform;


    void Start()
    {
        Character hero = new Character();
        Character hero2 = hero;
        hero2.name = "Sir Krane the Brave";

        hero.PrintStatsInfo();
        hero2.PrintStatsInfo();
        //hero2.Reset();

        //GameObject.Find("Directional Light").GetComponent<Transform>();
        
        //Debug.Log(lightTransform.localPosition);

        cameraTransform = this.GetComponent<Transform>();
        Debug.Log(cameraTransform.localPosition);

        Character heroine = new Character("Agatha");
        heroine.PrintStatsInfo();

        Weapon huntingBow = new Weapon("Hunting Bow", 105);
        Weapon huntingBow2 = huntingBow;
        huntingBow2.name = "war bow";
        huntingBow2.damage = 11;

        huntingBow.PrintWeaponStats();
        huntingBow2.PrintWeaponStats();

        Paladin knight = new Paladin("Sir Arthur", huntingBow);
        knight.PrintStatsInfo();

        string characterAction = "Attack";

        int playerLives = 3;

        while (playerLives > 0)
        {
            Debug.Log("he is alive");
            playerLives--;
        }
        Debug.Log("the end");

        List<string> questPartyMembers = new List<string>() { "character1", "character2", "character3" };
        Debug.Log(questPartyMembers.Count);

        for (int i = 0; i < questPartyMembers.Count; i++)
        {
            if (questPartyMembers[i] == "character2")
            {
                Debug.Log("true");
            }
        }


        Dictionary<string, int> itemInventory = new Dictionary<string, int>()
        {   {"first", 1},
            {"second", 2},
            {"third", 3}
        };
        Debug.Log(itemInventory.Count);

        if (weaponEquipped && weaponType == "Longsword")
        {
            Debug.Log("For the Queen!");
            OpenTreasureChamber();
            SwitchingAround();

        }
        else
        {
            Debug.Log("Fists aren't going to work against armor...");
        }



        switch (characterAction)
        {
            case "Heal":
                Debug.Log("Heal");
                break;

            case "Attack":
                Debug.Log("Attack");
                break;
            default:
                Debug.Log("default case");
                break;
        }
    }


    void Update()
    {

    }

    public void OpenTreasureChamber()
    {
        if (pureOfHeart && rareItem == "Brilliant")
        {
            if (!hasSecretIncantation)
            {
                Debug.Log("OpenTreasureChamber Method -- if -- inner");
            }
            else
            {
                Debug.Log("OpenTreasureChamber Method -- else -- inner");
            }
        }
        else
        {
            Debug.Log("OpenTreasureChamber Method -- else -- outer");
        }
    }

    public void SwitchingAround()
    {
        int diceRoll = 7;

        switch (diceRoll)
        {
            case 7:

            case 15:
                Debug.Log("15");
                break;
            case 20:
                Debug.Log("20");
                break;
        }

    }
}

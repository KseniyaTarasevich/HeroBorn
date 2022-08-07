using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using CustomExtensions;

public class GameBehavior : MonoBehaviour, IManager
{
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    private int _itemsCollected = 0;
    private int _playerHP = 10;
    private string _state;

    public Stack<string> lookStack = new Stack<string>();
    public delegate void DebugDelegate(string newText);
    public DebugDelegate debug = Print;

    public string State
    {
        get
        {
            return _state;
        }

        set
        {
            _state = value;
        }
    }

    public int Items
    {
        get
        {
            return _itemsCollected;
        }

        set
        {
            _itemsCollected = value;
            //Debug.LogFormat("Items: {0}", _itemsCollected);

            if (_itemsCollected >= maxItems)
            {

                //labelText = "You're found all items!";
                showWinScreen = true;
                SetText("You're found all items!");
                //Time.timeScale = 0f;
            }

            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    public int HP
    {
        get
        {
            return _playerHP;
        }

        set
        {
            _playerHP = value;

            if (_playerHP <= 0)
            {

                //labelText = "You want another life with that?";
                showLossScreen = true;
                SetText("You want another life with that?");
                //Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... that's got hurt.";
            }

            //Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    private void SetText(string newLabelText)
    {
        labelText = newLabelText;
        Time.timeScale = 0f;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                //RestartLevel();
                Utilities.RestartLevel(0);
            }
        }

        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
            {
                //RestartLevel();

                try
                {
                    Utilities.RestartLevel(-1);
                    debug("Level restarted successfully...");
                }
                catch (System.ArgumentException e)
                {
                    Utilities.RestartLevel(0);
                    debug("Reverting to scene 0: " + e.ToString());
                }
                finally
                {
                    debug("Restart handled...");
                }
            }
        }
    }

    void Start()
    {
        Initialize();

        InventoryList<string> inventoryList = new InventoryList<string>();

        inventoryList.SetItem("Potion");
        Debug.Log(inventoryList.item);
    }

    public void Initialize()
    {
        _state = "Manager initialized...";
        _state.FancyDebug();
        Debug.Log(_state);

        lookStack.Push("Sword of Doom");
        lookStack.Push("HP+");
        lookStack.Push("Golden Key");
        lookStack.Push("Winged Boot");
        lookStack.Push("Mythril Bracers");

        debug(_state);
        LogWithDelegate(debug);

        GameObject player = GameObject.Find("Player");

        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        playerBehavior.playerJump += HandlePlayerJump;
    }

    public void HandlePlayerJump()
    {
        debug("Player has jumped");
    }

    public static void Print(string newText)
    {
        Debug.Log(newText);
    }

    public void PrintLootReport()
    {
        var currentItem = lookStack.Pop();
        var nextitem = lookStack.Peek();

        Debug.LogFormat("You got a {0}! You've got a good chance of finding a {1} next!", currentItem, nextitem);

        Debug.LogFormat("There are {0} random loot times waiting for you!", lookStack.Count);
    }

    public void LogWithDelegate(DebugDelegate del)
    {
        del("Delegating the debug task...");
    }

    //void RestartLevel()
    //{
    //    SceneManager.LoadScene(0);
    //    Time.timeScale = 1f;
    //}
}

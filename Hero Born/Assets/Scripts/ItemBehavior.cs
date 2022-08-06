using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("Item Collected!");
        }
        gameManager.Items += 1;

        gameManager.PrintLootReport();
    }
}

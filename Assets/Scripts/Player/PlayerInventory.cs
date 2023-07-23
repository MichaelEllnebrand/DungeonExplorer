using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public int exitKeyCost { get; private set; } = 7;

    public bool hasExitKey { get; private set; } = false;
    public int coins { get; private set; } = 0;


    public void GetExitKey()
    {
        hasExitKey = true;
    }

    public void BuyKey()
    {
        if (coins >= exitKeyCost)
        {
            coins -= exitKeyCost;
            hasExitKey = true;
        }
    }

    public void GetCoin()
    {
        if (GameObject.Find("PlayerInteractUI").TryGetComponent(out PlayerInteractUI playerInteractUI))
        {
            playerInteractUI.ShowResponseMessage("Got a coin!");
        }
        coins++;
    }
}
using UnityEngine;

public class CoinInteractable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInventory playerInventory))
        {
            playerInventory.GetCoin();
            Destroy(gameObject);
        }
    }
}
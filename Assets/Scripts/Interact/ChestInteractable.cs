using UnityEngine;

public class ChestInteractable : MonoBehaviour, IInteractable
{
    private bool isChestSearched = false;

    public string GetInteractText()
    {
        return "Search chest";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(GameObject interactorGameobject)
    {
        if (!isChestSearched)
        {
            if (interactorGameobject.TryGetComponent(out PlayerInventory playerInventory))
            {
                playerInventory.GetCoin();
            }

            isChestSearched = true;
            Destroy(this);
        }
    }
}
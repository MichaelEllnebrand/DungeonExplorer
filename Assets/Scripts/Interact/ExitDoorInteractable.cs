using UnityEngine;

public class ExitDoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject doorClosed;
    [SerializeField] private PlayerInteractUI playerInteractUI;

    public string GetInteractText()
    {
        return "Open door";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(GameObject interactorGameobject)
    {
        if (interactorGameobject.TryGetComponent(out PlayerInventory inventory))
        {
            if (inventory.hasExitKey)
            {
                doorClosed.SetActive(false);
                playerInteractUI.ShowResponseMessage("You used the key and opened the door...");
                Destroy(this);
            }
            else
            {
                playerInteractUI.ShowResponseMessage("You don't have the key for this door...");
            }
        }
    }
}
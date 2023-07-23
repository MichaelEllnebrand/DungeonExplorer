using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject interactorGameobject);
    string GetInteractText();
    Transform GetTransform();
}
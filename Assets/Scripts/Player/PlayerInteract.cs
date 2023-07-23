using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float interactRange = 2.0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // TODO: Change to new input system
        {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact(gameObject);
            }
        }
    }

    public IInteractable GetInteractableObject()
    {
        List<IInteractable> interactables = new();
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactables.Add(interactable);
            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactables)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }
}
using System.Collections;
using UnityEngine;

public class OrcInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject text;
    [SerializeField] private float timeToShowText = 3;
    [SerializeField] private string interactText;

    private OrcState orcState = OrcState.wantCoin;

    enum OrcState
    {
        wantCoin,
        gaveKey
    }

    public void Interact(GameObject interactorGameobject)
    {
        if (interactorGameobject.TryGetComponent(out PlayerInventory playerInventory))
        {
            if (playerInventory.coins >= playerInventory.exitKeyCost)
            {
                if (GameObject.Find("PlayerInteractUI").TryGetComponent(out PlayerInteractUI playerInteractUI))
                {
                    playerInteractUI.ShowResponseMessage("Got a key!");
                }
                playerInventory.BuyKey();
                orcState = OrcState.gaveKey;
                Destroy(this);
            }
        }

        if (orcState == OrcState.wantCoin)
        {
            text.SetActive(true);
            StartCoroutine(HideText());
        }
    }

    public string GetInteractText()
    {
        return interactText;
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(timeToShowText);
        text.SetActive(false);
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private GameObject playerInteractUI;
    [SerializeField] private TextMeshProUGUI playerInteractText;
    [SerializeField] private GameObject playerResponseUI;
    [SerializeField] private TextMeshProUGUI playerInteractResponseText;
    [SerializeField] private float playerInteractResponseTime = 3.0f;

    private void Awake()
    {
        playerResponseUI.SetActive(false);
    }

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            ShowInteraction(playerInteract.GetInteractableObject());
        }
        else
        {
            HideInteraction();
        }
    }
    private void ShowInteraction(IInteractable interactable)
    {
        playerInteractUI.SetActive(true);
        playerInteractText.text = interactable.GetInteractText();
    }

    private void HideInteraction()
    {
        playerInteractUI.SetActive(false);
    }

    public void ShowResponseMessage(string message)
    {
        playerResponseUI.SetActive(true);
        playerInteractResponseText.text = message;
        StartCoroutine(HideInteractResponseDelayed());
    }

    IEnumerator HideInteractResponseDelayed()
    {

        yield return new WaitForSeconds(playerInteractResponseTime);
        playerInteractResponseText.text = "";
        playerResponseUI.SetActive(false);
    }
}
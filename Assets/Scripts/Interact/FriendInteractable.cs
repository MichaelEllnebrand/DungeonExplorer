using System.Collections;
using UnityEngine;

public class FriendInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject text;
    [SerializeField] private float timeToShowText = 1;
    [SerializeField] private string interactText;

    private bool isShowingText;

    public string GetInteractText()
    {
        return "Talk to friend";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(GameObject interactorGameobject)
    {
        if (!isShowingText)
        {
            isShowingText = true;
            text.SetActive(true);
            StartCoroutine(HideText());
        }
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(timeToShowText);
        text.SetActive(false);
        isShowingText = false;
    }
}
using System.Collections;
using UnityEngine;
using TMPro;

public class IntroUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI introText;

    private float introTextOffset = 0f;
    private float speed = 1f;

    void Start()
    {
        StartCoroutine(AnimateIntroText());
    }

    IEnumerator AnimateIntroText()
    {
        yield return new WaitForSeconds(5f);

        while (introText.transform.position.y > -400)
        {
            introTextOffset -= Time.deltaTime * speed;
            introText.transform.position += new Vector3(0, introTextOffset, 0);
            yield return null;
        }

        Destroy(gameObject);
    }
}
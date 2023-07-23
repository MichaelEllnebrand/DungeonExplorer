using System.Collections;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    [SerializeField] private float timeDelay = 0.1f;
    [SerializeField] private float minLightRange = 0.5f;
    [SerializeField] private float maxLightRange = 1.5f;
    private bool isFlickering = false;
    private Light _light;

    void Awake()
    {
        _light = GetComponent<Light>();
    }

    void Update()
    {
        if (!isFlickering)
        {
            StartCoroutine(FlickerLight());
        }
    }

    IEnumerator FlickerLight()
    {
        isFlickering = true;
        _light.intensity = Random.Range(minLightRange, maxLightRange);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
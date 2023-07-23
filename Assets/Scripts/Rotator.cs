using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 rotationDirection;
    [SerializeField] private float rotationSpeed;

    void Update()
    {
        transform.Rotate(Time.deltaTime * rotationSpeed * rotationDirection);
    }
}
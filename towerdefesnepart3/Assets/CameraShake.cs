using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.7f;
    private Vector3 originalPosition;
    private float currentShakeDuration;

    void Awake()
    {
        originalPosition = transform.localPosition;
    }

    public void TriggerShake()
    {
        currentShakeDuration = shakeDuration;
    }

    void Update()
    {
        if (currentShakeDuration > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }
}

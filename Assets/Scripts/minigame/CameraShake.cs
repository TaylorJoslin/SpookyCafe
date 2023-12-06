using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.7f;

    private Vector3 orignalPostion;

    private void Start()
    {
        orignalPostion = transform.localPosition;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCotoutine());
    }

    IEnumerator ShakeCotoutine()
    {
        float elasped = 0.0f;

        while (elasped< shakeDuration)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeIntensity;
            transform.localPosition = orignalPostion + shakeOffset;

            elasped += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = orignalPostion;
    }
}

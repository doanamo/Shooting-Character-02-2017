using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public GameObject muzzleFlash;
    public float duration = 0.1f;

    public void Activate()
    {
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        // Set muzzle flash to be visible for a brief moment.
        this.muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(this.duration);
        this.muzzleFlash.SetActive(false);

        // Rotate muzzle flash after it's hidden again.
        this.muzzleFlash.transform.Rotate(0.0f, 0.0f, 270.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public GameObject muzzleFlash;
    public float duration = 0.1f;

    new private AudioSource audio;

    public void Start()
    {
        this.audio = gameObject.GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        this.audio.PlayOneShot(audio.clip);
        StartCoroutine(MuzzleFlash());
    }

    IEnumerator MuzzleFlash()
    {
        // Set muzzle flash to be visible for a brief moment.
        this.muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(this.duration);
        this.muzzleFlash.SetActive(false);

        // Rotate muzzle flash after it's hidden again.
        this.muzzleFlash.transform.Rotate(0.0f, 0.0f, 270.0f);
    }
}

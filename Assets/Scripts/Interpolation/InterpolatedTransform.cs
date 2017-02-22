using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InterpolationUpdater))]
public class InterpolatedTransform : MonoBehaviour
{
    private struct TransformData
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
    }

    private TransformData[] lastTransforms;
    private int currentIndex;

    void Awake()
    {
        this.lastTransforms = new TransformData[2];
        this.currentIndex = 0;
    }

    void OnEnable()
    {
        this.ForgetPreviousTransform();
    }

    public void ForgetPreviousTransform()
    {
        this.lastTransforms[0].position = this.transform.localPosition;
        this.lastTransforms[0].rotation = this.transform.localRotation;
        this.lastTransforms[0].scale = this.transform.localScale;
        this.lastTransforms[1] = this.lastTransforms[0];
    }
    
    void FixedUpdate()
    {
        // Restore to current transform regardless of the interpolation.
        TransformData currentTransform = this.lastTransforms[this.currentIndex];

        this.transform.localPosition = currentTransform.position;
        this.transform.localRotation = currentTransform.rotation;
        this.transform.localScale = currentTransform.scale;
    }

    public void LateFixedUpdate()
    {
        // Save current transformation data.
        this.currentIndex = this.currentIndex == 0 ? 1 : 0;

        this.lastTransforms[this.currentIndex].position = transform.localPosition;
        this.lastTransforms[this.currentIndex].rotation = transform.localRotation;
        this.lastTransforms[this.currentIndex].scale = transform.localScale;
    }

    void Update()
    {
        // Retrieve last two transforms.
        int previousIndex = this.currentIndex == 0 ? 1 : 0;
        TransformData currentTransform = this.lastTransforms[this.currentIndex];
        TransformData previousTransform = this.lastTransforms[previousIndex];

        // Interpolate between last two transforms.
        float factor = InterpolationController.interpolationFactor;
        this.transform.localPosition = Vector3.Lerp(previousTransform.position, currentTransform.position, factor);
        this.transform.localRotation = Quaternion.Slerp(previousTransform.rotation, currentTransform.rotation, factor);
        this.transform.localScale = Vector3.Lerp(previousTransform.scale,currentTransform.scale, factor);
    }
}

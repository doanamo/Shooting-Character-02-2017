using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolationUpdater : MonoBehaviour
{
    private InterpolatedTransform interpolatedTransform;

    void Awake()
    {
        this.interpolatedTransform = this.GetComponent<InterpolatedTransform>();
    }
    
    void FixedUpdate()
    {
        // Call late fixed update after all other scripts.
        this.interpolatedTransform.LateFixedUpdate();
    }
}

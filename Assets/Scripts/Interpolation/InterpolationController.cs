using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolationController : MonoBehaviour
{
    private float[] lastFixedTimes;
    private int currentIndex;

    public static float interpolationFactor
    {
        get; private set;
    } 

    void Start()
    {
        // Debug test with low fixed update rate.
        // Time.fixedDeltaTime = 0.1f;

        this.lastFixedTimes = new float[2];
        this.currentIndex = 0;
    }

    void FixedUpdate()
    {
        // Save current time of the fixed frame time.
        this.currentIndex = this.currentIndex == 0 ? 1 : 0;
        this.lastFixedTimes[this.currentIndex] = Time.fixedTime;
    }

    void Update()
    {
        // Calculate the interpolation factor.
        int previousIndex = this.currentIndex == 0 ? 1 : 0;
        float currentTime = this.lastFixedTimes[this.currentIndex];
        float previousTime = this.lastFixedTimes[previousIndex];

        if(currentTime != previousTime)
        {
            InterpolationController.interpolationFactor = (Time.time - currentTime) / (currentTime - previousTime);
        }
        else
        {
            InterpolationController.interpolationFactor = 1.0f;
        }
    }
}

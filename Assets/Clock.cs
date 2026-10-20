using UnityEngine;
using System;
public class Clock : MonoBehaviour
{
    const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;
    [SerializeField]
    Transform hourPivot, minutePivot, secondPivot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
   

    void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hourPivot.localRotation =
            Quaternion.Euler(0f, 0f, -0.0083f * (float)time.TotalSeconds);
        minutePivot.localRotation =
            Quaternion.Euler(0f, 0f, -0.5f * (float)time.TotalSeconds);
        secondPivot.localRotation =
            Quaternion.Euler(0f, 0f, secondsToDegrees * DateTime.Now.Second);
    }
}

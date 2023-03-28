using System;
using UnityEngine;

public class AnalogClock : MonoBehaviour
{
    [SerializeField] private Transform HourHand;
    [SerializeField] private Transform MinuteHand;
    [SerializeField] private Transform SecondHand;

    private void Update()
    {
        DateTime currentTime = DateTime.Now;
        float hour = (float)currentTime.Hour % 12;
        float minute = (float)currentTime.Minute;
        float second = (float)currentTime.Second;

        float hourAngle = -360 * (hour / 12);
        float minuteAngle = -360 * (minute / 60);
        float secondAngle = -360 * (second / 60);

        HourHand.localRotation = Quaternion.Euler(0, 0, hourAngle);
        MinuteHand.localRotation = Quaternion.Euler(0, 0, minuteAngle);
        SecondHand.localRotation = Quaternion.Euler(0, 0, secondAngle);
    }
}
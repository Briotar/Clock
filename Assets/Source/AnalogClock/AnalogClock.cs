using System;
using UnityEngine;

public class AnalogClock : MonoBehaviour
{
    [SerializeField] private Transform HourHand;
    [SerializeField] private Transform MinuteHand;
    [SerializeField] private Transform SecondHand;

    public float HourHandRotation => HourHand.eulerAngles.z;
    public float MinuteHandRotation => MinuteHand.eulerAngles.z;

    private void Start()
    {
        LocalTime.Instance.HoursChanched += (hours) =>
        {
            SetHour(hours);
        };

        LocalTime.Instance.MinutsChanched += (minuts) =>
        {
            SetMinute(minuts);
        };

        LocalTime.Instance.SecondsChanched += (seconds) =>
        {
            SetSecond(seconds);
        };
    }

    private void OnDisable()
    {
        LocalTime.Instance.HoursChanched -= (hours) =>
        {
            SetHour(hours);
        };

        LocalTime.Instance.MinutsChanched -= (minuts) =>
        {
            SetMinute(minuts);
        };

        LocalTime.Instance.SecondsChanched -= (seconds) =>
        {
            SetSecond(seconds);
        };
    }

    private void SetHour(int hour)
    {
        float hourAngle = 360 * ((float)hour / 12);
        HourHand.localRotation = Quaternion.Euler(0, 0, hourAngle);
    }

    private void SetMinute(int minute)
    {
        float minuteAngle = 360 * ((float)minute / 60);
        MinuteHand.localRotation = Quaternion.Euler(0, 0, minuteAngle);
    }

    private void SetSecond(float second)
    {
        float secondAngle = 360 * (second / 60);
        SecondHand.localRotation = Quaternion.Euler(0, 0, secondAngle);
    }
}
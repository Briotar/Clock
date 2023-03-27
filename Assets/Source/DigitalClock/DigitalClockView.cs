using UnityEngine;
using TMPro;

[RequireComponent(typeof(DigitalClock))]
public class DigitalClockView : MonoBehaviour
{
    [SerializeField] private TMP_Text _hours;
    [SerializeField] private TMP_Text _minuts;

    private DigitalClock _digitalClock;
    private int TwoDigitNumber = 10;

    private void Start()
    {
        _digitalClock = GetComponent<DigitalClock>();

        _digitalClock.HoursChanched += (hours) =>
        {
            SetTime(_hours, hours);
        };

        _digitalClock.MinutsChanched += (minuts) =>
        {
            SetTime(_minuts, minuts);
        };
    }

    private void OnDisable()
    {
        _digitalClock.HoursChanched -= (hours) =>
        {
            SetTime(_hours, hours);
        };

        _digitalClock.MinutsChanched -= (minuts) =>
        {
            SetTime(_minuts, minuts);
        };
    }

    private void SetTime(TMP_Text timeType, int value)
    {
        if (value < TwoDigitNumber)
        {
            timeType.text = "";
            timeType.text += "0";
            timeType.text += value.ToString();
        }
        else
        {
            timeType.text = value.ToString();
        }
    }
}
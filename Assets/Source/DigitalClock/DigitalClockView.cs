using UnityEngine;
using TMPro;

public class DigitalClockView : MonoBehaviour
{
    [SerializeField] private TMP_Text _hours;
    [SerializeField] private TMP_Text _minuts;

    private int TwoDigitNumber = 10;

    private void Start()
    {
        LocalTime.Instance.HoursChanched += (hours) =>
        {
            SetTime(_hours, hours);
        };

        LocalTime.Instance.MinutsChanched += (minuts) =>
        {
            SetTime(_minuts, minuts);
        };
    }

    private void OnDisable()
    {
        LocalTime.Instance.HoursChanched -= (hours) =>
        {
            SetTime(_hours, hours);
        };

        LocalTime.Instance.MinutsChanched -= (minuts) =>
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
using UnityEngine;

public class AnalogAlarmTime : MonoBehaviour
{
    private int[] _hourDegree = new int [12];
    private int[] _minuteDegree = new int[60];

    private int _hourAlarmRotation;
    private int _minuteAlarmRotation;

    public int HourAlarmRotation => _hourAlarmRotation;
    public int MinuteAlarmRotation => _minuteAlarmRotation;

    private void Start()
    {
        int hourDegreeIncrease = 360 / 12;
        int hourDegree = 0;
        int minuteDegreeIncrease = 360 / 60;
        int minuteDegree = 0;

        for (int i = 0; i < _hourDegree.Length; i++)
        {
            _hourDegree[i] = hourDegree;
            hourDegree += hourDegreeIncrease;
        }

        for (int i = 0; i < _minuteDegree.Length; i++)
        {
            _minuteDegree[i] = minuteDegree;
            minuteDegree += minuteDegreeIncrease;
        }
    }

    private int SetAlarmTime(int timeValue ,int[] degrees)
    {
        for (int i = 0; i < degrees.Length; i++)
        {
            if (timeValue < degrees[i])
            {
                int diffPrev = (int)timeValue - degrees[i - 1];
                int diffNext = degrees[i] - (int)timeValue;

                if (diffPrev > diffNext)
                    return degrees[i];
                else
                    return degrees[i - 1];
            }
        }

        return 0;
    }

    public void SetAlarmTime(float hourHandRotation, float minuteHandRotation)
    {
        //Debug.Log("Hour rotation: " + hourHandRotation);
        //Debug.Log("Minute rotation: " + minuteHandRotation);

        _hourAlarmRotation = SetAlarmTime((int)hourHandRotation, _hourDegree);
        _minuteAlarmRotation = SetAlarmTime((int)minuteHandRotation, _minuteDegree);

        //Debug.Log("Hour alarm rotation: " + _hourAlarmRotation);
        //Debug.Log("Minute alarm rotation: " + _minuteAlarmRotation);
    }
}
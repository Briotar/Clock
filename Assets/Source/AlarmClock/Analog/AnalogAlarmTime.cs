using UnityEngine;
using TMPro;

public class AnalogAlarmTime : MonoBehaviour
{
    [SerializeField] private TMP_Text _alarmText;

    private int[] _hourDegree = new int [12];
    private int[] _minuteDegree = new int[60];

    private int _hourAlarmRotation;
    private int _minuteAlarmRotation;

    private int _hourAlarm;
    private int _minuteAlarm;

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

    private int SetAlarmTime(int timeValue ,int[] degrees, bool isHour)
    {
        for (int i = 0; i < degrees.Length; i++)
        {
            if (timeValue < degrees[i])
            {
                int diffPrev = (int)timeValue - degrees[i - 1];
                int diffNext = degrees[i] - (int)timeValue;

                if (diffPrev > diffNext)
                {
                    if (isHour)
                        _hourAlarm = i;
                    else
                        _minuteAlarm = i;

                    return degrees[i];
                }
                else
                {
                    if (isHour)
                        _hourAlarm = i - 1;
                    else
                        _minuteAlarm = i - 1;

                    return degrees[i - 1];
                }
            }
        }

        return 0;
    }

    public void SetAlarmTime(float hourHandRotation, float minuteHandRotation)
    {
        _hourAlarmRotation = SetAlarmTime((int)hourHandRotation, _hourDegree, true);
        _minuteAlarmRotation = SetAlarmTime((int)minuteHandRotation, _minuteDegree, false);

        _alarmText.text = "Будильник прозвонит в " + _hourAlarm + ":" + _minuteAlarm + " по аналоговым часам";
    }

    public void AlarmOff()
    {
        _hourAlarmRotation = -1;
        _minuteAlarmRotation = -1;
    }
}
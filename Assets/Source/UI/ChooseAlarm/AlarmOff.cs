using UnityEngine;
using UnityEngine.UI;

public class AlarmOff : MonoBehaviour
{
    [SerializeField] private GameObject _digitalTimeAlarm;
    [SerializeField] private GameObject _analogTimeAlarm;
    [SerializeField] private Button _chooseButton;
    [SerializeField] private AnalogAlarmTime _analogAlarmTime;
    [SerializeField] private DigitalAlarmInput _digitalAlarmInput;
    [SerializeField] private AudioSource _audioSource;

    public void OnDigitalAlarmOff()
    {
        _digitalTimeAlarm.SetActive(false);
        _chooseButton.gameObject.SetActive(true);
        _digitalAlarmInput.AlarmOff();
        _audioSource.Stop();
    }

    public void OnAnalogAlarmOff()
    {
        _analogTimeAlarm.SetActive(false);
        _chooseButton.gameObject.SetActive(true);
        _analogAlarmTime.AlarmOff();
        _audioSource.Stop();
    }
}
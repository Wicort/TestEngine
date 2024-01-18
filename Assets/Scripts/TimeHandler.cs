using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private QuestionHandler _questionHandler;
    [SerializeField] private int _timeForQuestion = 5;

    public bool TimeIsEnded;

    public static Action OnTimeIsEnded;

    private int _time;

    private void Awake()
    {
        _time = _questionHandler.QuestionCount * _timeForQuestion;
        TimeIsEnded = false;
    }

    private void Start()
    {
        StartCoroutine(DoTimer());
    }

    private void Update()
    {
        _timeText.text = _time.ToString();
    }

    IEnumerator DoTimer()
    {
        while (true)
        { 
            yield return new WaitForSeconds(1f);
            _time--;
            if (_time <= 0)
            {
                TimeIsEnded = true;
                OnTimeIsEnded?.Invoke();
                break;
            }
        }
    }
}

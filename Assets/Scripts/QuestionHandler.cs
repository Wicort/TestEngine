using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestionHandler : MonoBehaviour
{
    [SerializeField] private List<Question> _questions;
    private List<Question> _awailableQuestions;

    public static Action OnRanOutOfQuestions;

    public int QuestionCount => _questions.Count;

    public void Init()
    {
        _awailableQuestions = new List<Question>(_questions);
    }

    public Question GetNextQuestion()
    {
        if (_awailableQuestions.Count == 0)
        {
            // todo убрать заглушку
            //_awailableQuestions = new List<Question>(_questions);
            return null;
        }

        int questionNum = UnityEngine.Random.Range(0, _awailableQuestions.Count);

        Question questionInList = _awailableQuestions[questionNum];

        Question nextQuestion = new(questionInList);
        _awailableQuestions.Remove(questionInList);

        return nextQuestion;
    }

    private void Awake()
    {
        Init();
    }

    public void RanOutOfQuestions()
    {
        OnRanOutOfQuestions?.Invoke();
    }
}

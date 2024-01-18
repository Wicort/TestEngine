using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionView : MonoBehaviour
{

    [SerializeField] 
    private TextMeshProUGUI _questionText;
    [SerializeField] 
    private Button _answer1Button;
    [SerializeField] 
    private TextMeshProUGUI _answer1Text;
    [SerializeField] 
    private Button _answer2Button;
    [SerializeField] 
    private TextMeshProUGUI _answer2Text;
    [SerializeField] 
    private Button _answer3Button;
    [SerializeField] 
    private TextMeshProUGUI _answer3Text;
    [SerializeField] 
    private Button _answer4Button;
    [SerializeField] 
    private TextMeshProUGUI _answer4Text;
    [SerializeField] 
    private TextMeshProUGUI _questionNumberText;

    [SerializeField] 
    private QuestionHandler _questionHandler;

    [SerializeField]
    private Question _question;
    private int _questionNumber;

    public static Action<int> OnDoCorrectAnswer;
    public static Action<int> OnDoInCorrectAnswer;


    private void Start()
    {
        _questionNumber = 0;
        nextQuestion();
    }

    private void nextQuestion()
    {
        _question = _questionHandler.GetNextQuestion();

        if (_question == null)
        {
            _questionHandler.RanOutOfQuestions();
        }
        else
        {
            _questionNumber++;
            ShowQuestion();
        }
    }

    public void ShowQuestion()
    {
        _questionNumberText.text = "Вопрос #" + _questionNumber + "/" + _questionHandler.QuestionCount;

        _questionText.text = _question.QuestionText;

        _answer1Text.text = _question.Answer1;
        _answer2Text.text = _question.Answer2;
        _answer3Text.text = _question.Answer3;
        _answer4Text.text = _question.Answer4;        
    }

    public void OnAnswer1Clicked()
    {
        DoAnswer(1);
    }
    public void OnAnswer2Clicked()
    {
        DoAnswer(2);
    }
    public void OnAnswer3Clicked()
    {
        DoAnswer(3);
    }
    public void OnAnswer4Clicked()
    {
        DoAnswer(4);
    }

    private void DoAnswer(int answerId)
    {
        bool answerIsCorrect = _question.DoAnswer(answerId);
        if (answerIsCorrect)
        {
            OnDoCorrectAnswer?.Invoke(1);
        } else
        {
            OnDoInCorrectAnswer?.Invoke(0);
        }
        nextQuestion();
    }

}

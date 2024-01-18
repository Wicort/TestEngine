using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;

    public int Scores => _score;

    private void OnEnable()
    {
        QuestionView.OnDoCorrectAnswer += AddScore;
        QuestionView.OnDoInCorrectAnswer += DecreseScore;
    }

    private void OnDisable()
    {
        QuestionView.OnDoCorrectAnswer -= AddScore;
        QuestionView.OnDoInCorrectAnswer -= DecreseScore;
    }

    private void AddScore(int value)
    {
        _score += value;
        _scoreText.text = "Текущий счет: " + _score;
    }

    private void DecreseScore(int value)
    {
        _score -= value;
        if (_score < 0 )
        {
            _score = 0;
        }
        _scoreText.text = "Текущий счет: " + _score;
    }
}

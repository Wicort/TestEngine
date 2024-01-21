using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private QuestionHandler _questionHandler;
    [SerializeField] private TimeHandler _timeHandler;

    private void OnEnable()
    {
        if (_score.Scores >= PlayerPrefs.GetInt("Scores", 0))
        {
            PlayerPrefs.SetInt("Scores", _score.Scores);
            YandexGame.NewLeaderboardScores("Scores", _score.Scores);
            
        }
        _scoreText.text = (_timeHandler.TimeIsEnded ? "����� �����!\n" : "") + "��� ����: " + _score.Scores.ToString() + " �� " + _questionHandler.QuestionCount;
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void OnReplyButtonClick()
    {
        SceneManager.LoadScene("QuestionScene");
    }
}

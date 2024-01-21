using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private QuestionView _questionView;
    [SerializeField] private GameObject _menuUI;
    [SerializeField] private EndGame _endGameUi;

    private void OnEnable()
    {
        QuestionHandler.OnRanOutOfQuestions += EndGame;
        //QuestionView.OnDoInCorrectAnswer += EndGame;
        TimeHandler.OnTimeIsEnded += EndGame;
    }

    private void OnDisable()
    {
        QuestionHandler.OnRanOutOfQuestions -= EndGame;
        //QuestionView.OnDoInCorrectAnswer -= EndGame;
        TimeHandler.OnTimeIsEnded -= EndGame;
    }

    private void Start()
    {
        _questionView.gameObject.SetActive(true);
        _menuUI.SetActive(true);
        _endGameUi.gameObject.SetActive(false);
    }

    private void EndGame()
    {
        StartCoroutine(showFullScreen());

        _questionView.gameObject.SetActive(false);
        _menuUI.SetActive(false);
        _endGameUi.gameObject.SetActive(true);
        

    }

    IEnumerator showFullScreen()
    {
        yield return new WaitForSeconds(1f);
        YandexGame.FullscreenShow();
    }

    private void EndGame(int value)
    {
        EndGame();
    }
}

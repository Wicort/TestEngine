using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("QuestionScene");
    }
}

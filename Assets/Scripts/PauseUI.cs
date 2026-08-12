using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;

    void Start()
    {
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseUI.activeSelf)
            {
                BtnResumeClick();
            }
            else
            {
                pauseUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void BtnResumeClick()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BtnQuitClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

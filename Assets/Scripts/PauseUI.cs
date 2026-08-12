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
            pauseUI.SetActive(true);
        }     
    }

    public void BtnResumeClick()
    {
        pauseUI.SetActive(false);
    }

    public void BtnQuitClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

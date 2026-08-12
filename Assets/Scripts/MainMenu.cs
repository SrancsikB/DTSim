using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void BtnSimulateClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BtnQuitClick()
    {
        Application.Quit();
    }
}

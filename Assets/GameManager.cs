using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Panels")]
    public GameObject mainMenuUI;

    private bool isGameOver = false;

    void Awake()
    {

        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

   


    public void StartGame()
    {
        isGameOver = false;
        mainMenuUI.SetActive(false);

        
    }

   
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ExitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }


    public void ShowMainMenu()
    {
        Time.timeScale = 0f;
        mainMenuUI.SetActive(true);

    }

    public bool IsGameOver()
{
    return isGameOver;
}
}
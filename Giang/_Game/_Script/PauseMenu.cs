using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    GameObject player;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    private void Update()
    {
       if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;

        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}

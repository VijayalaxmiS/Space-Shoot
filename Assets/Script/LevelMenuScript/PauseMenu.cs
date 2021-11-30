using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private AudioSource buttontap;
    bool isPaused;
    public GameObject pauseScreen;
    // Start is called before the first frame update

    void Awake()
    {
        buttontap = GetComponent<AudioSource>();

    }
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isPaused)
            {
            Time.timeScale = 0;
              
            }
            else
            {
            Time.timeScale = 1;
        
        }
    }

    public void ResumeGame()
    {
        buttontap.Play();
        isPaused = false;
            pauseScreen.SetActive(false);
    }

    public void PauseGame()
    {
        buttontap.Play();
        isPaused = true;
        pauseScreen.SetActive(true);
    }

    public void PlayGame()
    {
        buttontap.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        buttontap.Play();
        Application.Quit();
    }
}

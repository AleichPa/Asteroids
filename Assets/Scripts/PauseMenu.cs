using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    float startTime;
    public TextMeshProUGUI tiempo;
    public GameObject PauseMenus;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
   private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseButton();
        }
    }

    public void PauseButton()
    {
        PauseMenus.SetActive(true);
        Time.timeScale = 0;
    }
    public void PlayButton()
    {
        PauseMenus.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}

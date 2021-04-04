using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public InputField Username;
    public Slider fallSpeed;

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");

        PauseMenu.WordCount = 0;
    }

    public void SliderFallSpeed()
    {
        PlayerPrefs.SetFloat("FallSpeed", fallSpeed.value);
    }

    public void Name()
    {
        Debug.Log("Player name is: " + Username.text);
        PlayerName.username = Username.text;

        string user = Username.GetComponent<InputField>().text;
        PlayerPrefs.SetString("Username", user);

    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void Highscores()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

}

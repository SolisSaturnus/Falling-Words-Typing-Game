using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
   
    
    public static string username;
    public static int WordCount;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text UsernameText;


    void Start()
    {
        WordCount = 0;


        username = PlayerPrefs.GetString("Username");
        UsernameText.text = username;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        scoreText.text = "Score: " + WordCount.ToString();

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()

    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Main");
        Resume();
    }

    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private AudioSource myAudio;


    public void Awake()
    {
        // 1
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            toggle.isOn = true;
            myAudio.enabled = true;
            PlayerPrefs.Save();
        }
        // 2
        else
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                myAudio.enabled = false;
                toggle.isOn = false;
            }
            else
            {
                myAudio.enabled = true;
                toggle.isOn = true;
            }
        }
    }

    public void ToggleMusic()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            myAudio.enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            myAudio.enabled = false;
        }
        PlayerPrefs.Save();
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.score = WordCount;
        save.username = username;

        return save;
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        WordCount = 0;
        username = "";

        Debug.Log("Game Saved");
    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            scoreText.text = "Score: " + save.score;
            UsernameText.text = save.username;
            WordCount = save.score;
            username = save.username;

            Debug.Log("Game Loaded");

            Resume();
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    public void SaveAsJson()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as Json: " + json);
    }

    public void MainScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }


    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}



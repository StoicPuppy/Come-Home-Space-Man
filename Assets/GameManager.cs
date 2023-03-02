using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Vector3 InitPosition;
    private GameObject SpaceMan;

    private AsyncOperation async;

    public GameObject pauseMenu;
    public static bool IsPaused = false;
    public GameObject buttonResume;

    [SerializeField] private AudioSource pickUpSound;

    public static GameManager instance = null;

    public bool HasEnoughFruit = false;

    [SerializeField] private GameObject[] levels;
    private int CurrentLVL = 0;
    private GameObject CurrentMap;

    public Text Total;

    public Text Message;
    public Text FruitCount;
    public int NumberOfFruit = 0;
    public int TotalNumberFruit = 0;

    [SerializeField] private GameObject Congrats;

    [SerializeField] private GameObject[] particle;

    [SerializeField] GameObject[] hearts;
    private int lives = 3;



    // Start is called before the first frame update
    void Awake()
    {
        Total.enabled = false;
        pauseMenu.SetActive(false);
        IsPaused = false;
        Message.enabled = false;
        SpaceMan = GameObject.Find("Space Man");
        InitPosition = SpaceMan.transform.position;
        TotalNumberFruit = PlayerPrefs.GetInt("Fruit Collected", TotalNumberFruit);
        HasEnoughFruit = false;

        LoadLVL();
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }

    }

    void LoadLVL()
    {
        if(CurrentMap)
        {
            Destroy(CurrentMap);
        }
        CurrentMap = Instantiate(levels[CurrentLVL]);
    }
    public void CanGoHome()
    {
        if(NumberOfFruit >= 12)
        {
            HasEnoughFruit = true;
        }
        else
        {
            Message.enabled = true;
            Message.text = "You have to collect 12 fruits!";
            Invoke("Deactivatetext", 3);
        }
    }

    public void Deactivatetext()
    {
        Message.enabled = false;
    }

    public void NextLevel()
    {
        if(CurrentLVL < levels.Length - 1)
        {
            CurrentLVL++;
            PlayerPrefs.SetInt("Fruits : ", TotalNumberFruit);
            PlayerPrefs.Save();
            NumberOfFruit = 0;
            LoadLVL();
            SpaceMan.transform.position = InitPosition;
        } 
        else
        {
            Congrats.GetComponent<ParticleSystem>().Play();
            Total.enabled = true;
            Total.text = "You have found: " + TotalNumberFruit + " Fruits! ";
            pauseMenu.SetActive(true);
            buttonResume.SetActive(false);
            Message.enabled = true;
            Message.text = "You have made it home and with yummy fruits!";
        }
    }

    public void Quit(int index)
    {
        if (async == null)
        {
            async = SceneManager.LoadSceneAsync(index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Cancel"))
        {
            if(!IsPaused)
            {
                IsPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                IsPaused = false;
                Resume();
            }
        }
    }

    public void Resume()
    {
        IsPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }


    public void PlayParticle(int index, GameObject obj)
    {
        particle[index].transform.position = obj.transform.position; 

        particle[index].GetComponent<ParticleSystem>().Play();
        pickUpSound.Play();

        Destroy(obj);
    }

    public void Takedamage()
    {

        if (lives > 1)
        {
            hearts[lives - 1].SetActive(false);
        }
        else
        {
            hearts[0].SetActive(false);
        }
        lives--;
        if (IsDead())
        {
            GameOver();
        }

    }

    public bool IsDead()
    {
        return (this.lives <= 0);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        buttonResume.SetActive(false);
        Message.enabled = true;
        Message.text = "You Died!";
    }
}

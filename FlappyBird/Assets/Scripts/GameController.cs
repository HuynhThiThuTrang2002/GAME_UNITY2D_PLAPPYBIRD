using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Reflection.Emit;

public class GameController : MonoBehaviour
{
    public bool isEndGame;
    bool isStartFirstTime = true;
    int gamePoint = 0;
    public Text txtPoint;

    public GameObject pnlStartGame;
    public Text txtGame;
    public Button btnStart;

    public GameObject pnlEndGame;
    public Text txtEndPoint;
    public Button btnRestart;

    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        isEndGame = false;
        isStartFirstTime = true;
        pnlEndGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButtonDown(0) && isStartFirstTime)
            {
                StartGame();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                pnlStartGame.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (isEndGame)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isStartFirstTime)
            {
                StartGame();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pnlStartGame.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void RestartButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;
    }

    public void RestartButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }

    public void RestartButtonIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }

    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

    void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        StartGame();
    }

    public void EndGame()
    {
        isEndGame = true;
        isStartFirstTime = false;
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
        txtEndPoint.text = "Your point\n" + gamePoint.ToString();
    }
}

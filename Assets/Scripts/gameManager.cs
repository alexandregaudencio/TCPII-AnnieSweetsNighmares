using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    //canvas cena principal
    public string nomeFase;
    public GameObject pauseUi;
    public GameObject controlUi;
    public GameObject optionsUi;
    //cena Menu
    public string proximaFase1;
    public string proximaFase2;
    public GameObject menuUi;
    public GameObject menu;
    public GameObject creditoUi;
    public GameObject credito;
    public GameObject jogarUi;
    public GameObject jogar;
    public GameObject twoPlayers;
    public GameObject gameOverUi;
    public GameObject vitoriaUi;


    //public GameObject opcoes;
    //public GameObject menuUi;
    //public GameObject credito;
    //public AudioSource botao;


    void Start()
    {
        instance = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            continuar();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            restart();
        }

    }
    public void restart()
    {
        SceneManager.LoadScene(nomeFase);
        Time.timeScale = 1f;
        gameOverUi.SetActive(false);
        vitoriaUi.SetActive(false);

    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
        // botao.Play();
    }
    public void play1()
    {
        SceneManager.LoadScene(proximaFase1);
        // botao.Play();
    }
    public void play2()
    {

        SceneManager.LoadScene("TesteUrso");
        // botao.Play();
    }

    public void CreateInvoke(string functionName)
    {
        Invoke(functionName, 1.0f);
    }


    public void quit()
    {
        Application.Quit();
        //botao.Play();

    }
    public void pause()
    {
        //player.instance.cliques.Play();
        Time.timeScale = 0f;
        pauseUi.SetActive(true);
        //pausado.SetActive(true);

    }
    public void continuar()
    {
        //player.instance.cliques.Play();
        Time.timeScale = 1f;
        pauseUi.SetActive(false);
        controlUi.SetActive(false);
        // pausado.SetActive(false);
    }
    public void controls()
    {
        //player.instance.cliques.Play();

        controlUi.SetActive(true);
        pauseUi.SetActive(false);
    }
    public void options()
    {
        //player.instance.cliques.Play();

        optionsUi.SetActive(true);
        pauseUi.SetActive(false);

    }
    public void back()
    {
        optionsUi.SetActive(false);
        pauseUi.SetActive(true);
        controlUi.SetActive(false);
    }
    public void creditos()
    {
        //player.instance.cliques.Play();

        //menu.SetActive(false);
        menuUi.SetActive(false);
        creditoUi.SetActive(true);
        credito.SetActive(true);
    }
    public void escolherJogador()
    {

        menuUi.SetActive(false);
        jogarUi.SetActive(true);

    }
    public void backMenu()
    {
        menuUi.SetActive(true);
        //menu.SetActive(true);
        creditoUi.SetActive(false);
        credito.SetActive(false);
        jogarUi.SetActive(false);
    }
    public void gameOver()
    {
        gameOverUi.SetActive(true);
        Time.timeScale = 0f;


    }
    public void vitoria()
    {
        vitoriaUi.SetActive(true);
        Time.timeScale = 0f;


    }
    /*
      public void menu()
      {
          opcoes.SetActive(false);
          menuUi.SetActive(true);
          credito.SetActive(false);
          botao.Play();


      }
      public void creditos()
      {
          credito.SetActive(true);
          menuUi.SetActive(false);
          botao.Play();
      }*/

    public void StartTwoPlayerGame()
    {

    }
}

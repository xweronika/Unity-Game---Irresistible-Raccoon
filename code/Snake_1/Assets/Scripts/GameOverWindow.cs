using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    private static GameOverWindow instance;
    private void Awake()
    {
        instance = this;
        transform.Find("retryBtn").GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.GameScene);
        transform.Find("retryBtn").GetComponent<Button_UI>().AddButtonSound(); // dzwieki do przyciskow

        transform.Find("backBtn").GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.MainMenu);
        // po kliknieciu przycisku main menu wroc do sceny glownego menu
        transform.Find("backBtn").GetComponent<Button_UI>().AddButtonSound(); // dzwieki do przyciskow

        Hide();
    }
    private void Show(bool isNewHighscore)
    {
        gameObject.SetActive(true);
        transform.Find("newHighscoreText").gameObject.SetActive(isNewHighscore);
        // jesli jest nowy najwyzszy wynik to pokaz go, pojawia sie po tym gdy nastepuje koniec gry
        transform.Find("scoreText").GetComponent<Text>().text = Score.GetScore().ToString();
        transform.Find("scoreText (1)").GetComponent<Text>().text = Score.GetScore().ToString();

        transform.Find("highscoreText").GetComponent<Text>().text = "HIGHSCORE " + Score.GetHighscore(GameHandler.getLevel());
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    public static void ShowStatic(bool isNewHighscore)
    {
        instance.Show(isNewHighscore);
    }
}

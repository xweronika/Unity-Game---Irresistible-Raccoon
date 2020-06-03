using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PauseWindow : MonoBehaviour
{
    private static PauseWindow instance;

    private void Awake()
    {
        instance = this;

        transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // zmieniamy polozenie okna na srodek

        transform.Find("resumeBtn").GetComponent<Button_UI>().ClickFunc = () => GameHandler.ResumeGame();
        transform.Find("resumeBtn").GetComponent<Button_UI>().AddButtonSound(); // dzwieki do przyciskow

        // pauzowanie gry za pomoca funkcji z GameHandler
        transform.Find("mainMenuBtn").GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.MainMenu);
        // po kliknieciu przycisku main menu wroc do sceny glownego menu
        transform.Find("mainMenuBtn").GetComponent<Button_UI>().AddButtonSound(); // dzwieki do przyciskow



        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    public static void ShowStatic()
    {
        instance.Show();
    }
    public static void HideStatic()
    {
        instance.Hide();
    }
}

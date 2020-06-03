using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey;
using CodeMonkey.Utils;

public class MainMenuWindow : MonoBehaviour
{
    private enum Sub
    {
        Main,
        HowToPlay,
        LvlSelect
    }

    private void Awake()
    {
        transform.Find("howToPlaySub").Find("howToPlay").GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 90.0f);
        transform.Find("howToPlaySub").Find("backBtn").GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, -250.0f);
        // zmieniamy polozenie okna na okreslone wspolrzedne
        transform.Find("mainSub").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        // zmieniamy polozenie okna na srodek

        // odniesienie do przycisku play
        // po kliknieciu uruchamiana jest
        // nastepujaca funkcja
        transform.Find("mainSub").Find("playBtn").GetComponent<Button_UI>().ClickFunc = () => ShowSub(Sub.LvlSelect);
            // wczytujemy scene gry wczesniej uzywajac loadera 
            // i ladujemy program ladujacy dla sceny gry

            transform.Find("mainSub").Find("playBtn").GetComponent<Button_UI>().AddButtonSound(); // dzwieki do przyciskow

       transform.Find("mainSub").Find("quitBtn").GetComponent<Button_UI>().ClickFunc = () => Application.Quit();
        // aby wyjsc z gry klikamy przycisk quitBtn, przy pliku exe wracamy do pulpitu
        transform.Find("mainSub").Find("quitBtn").GetComponent<Button_UI>().AddButtonQuitSound(); // dzwieki do przyciskow

        transform.Find("mainSub").Find("howToPlayBtn").GetComponent<Button_UI>().ClickFunc = () =>  ShowSub(Sub.HowToPlay);
        transform.Find("mainSub").Find("howToPlayBtn").GetComponent<Button_UI>().AddButtonSound(); // dzwieki do przyciskow


        transform.Find("howToPlaySub").Find("backBtn").GetComponent<Button_UI>().ClickFunc = () => ShowSub(Sub.Main);
        // przycisk powrotu z instrukcji jak grac

        transform.Find("howToPlaySub").Find("backBtn").GetComponent<Button_UI>().AddButtonSound(); // dzwieki do przyciskow


        transform.Find("lvlSelect").Find("lvl1").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene); GameHandler.setLevel(1); };
        transform.Find("lvlSelect").Find("lvl2").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene); GameHandler.setLevel(2); };
        transform.Find("lvlSelect").Find("lvl3").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene); GameHandler.setLevel(3); };
        transform.Find("lvlSelect").Find("lvl4").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene); GameHandler.setLevel(4); };
        transform.Find("lvlSelect").Find("lvl5").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene); GameHandler.setLevel(5); };

        transform.Find("lvlSelect").Find("lvl1").GetComponent<Button_UI>().AddButtonSound();
        transform.Find("lvlSelect").Find("lvl2").GetComponent<Button_UI>().AddButtonSound();
        transform.Find("lvlSelect").Find("lvl3").GetComponent<Button_UI>().AddButtonSound();
        transform.Find("lvlSelect").Find("lvl4").GetComponent<Button_UI>().AddButtonSound();
        transform.Find("lvlSelect").Find("lvl5").GetComponent<Button_UI>().AddButtonSound();

        transform.Find("lvlSelect").Find("lvl1").Find("hs").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore1").ToString();
        transform.Find("lvlSelect").Find("lvl2").Find("hs").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore2").ToString();
        transform.Find("lvlSelect").Find("lvl3").Find("hs").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore3").ToString();
        transform.Find("lvlSelect").Find("lvl4").Find("hs").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore4").ToString();
        transform.Find("lvlSelect").Find("lvl5").Find("hs").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore5").ToString();

        transform.Find("lvlSelect").Find("backBtn").GetComponent<Button_UI>().ClickFunc = () => ShowSub(Sub.Main);
        transform.Find("lvlSelect").Find("backBtn").GetComponent<Button_UI>().AddButtonSound();

        ShowSub(Sub.Main);
    }

    // funkcja ktora wyswietla konkretne submenu
    private void ShowSub(Sub sub)
    {
        // najpierw ukrywamy oba submena
        transform.Find("mainSub").gameObject.SetActive(false);
        transform.Find("howToPlaySub").gameObject.SetActive(false);
        transform.Find("lvlSelect").gameObject.SetActive(false);

        // i switchem wybieramy ktore submenu chcemy pokazac
        switch (sub)
        {
            case Sub.Main:
                transform.Find("mainSub").gameObject.SetActive(true);
                break;

            case Sub.HowToPlay:
                transform.Find("howToPlaySub").gameObject.SetActive(true);
                break;

            case Sub.LvlSelect:
                transform.Find("lvlSelect").gameObject.SetActive(true);
                break;

        }

    }
}

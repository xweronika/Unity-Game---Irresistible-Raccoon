using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private static ScoreWindow instance;
    private Text scoreText; // tekst z punktami
    public List<Image> hearts;
    private void Awake()
    {
        instance = this;

        // bedziemy pobierac referencje do naszego obiektu tekstowego
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        // teraz mamy odniesienie do naszego tekstu
        // ktory mozemy zmienic aby byl aktualny wynik
    }

    public void lowerHp(int target)
    {
        hearts[target].GetComponent<Image>().sprite = GameAssets.i.heart_e;
    }

    public void increaseHp(int target)
    {
        hearts[target-1].GetComponent<Image>().sprite = GameAssets.i.heart;
    }

    private void Start()
    {
        Score.OnHighscoreChanged += Score_OnHighscoreChanged;
        UpdateHighscore();
    }

    private void Score_OnHighscoreChanged(object sender, System.EventArgs e)
    {
        UpdateHighscore();
    }

    private void Update()
    {
        // funkcja aktualizujaca wynik
        scoreText.text = Score.GetScore().ToString();
    }

    // funkcja aktualizacji najwyzszego wyniku
    private void UpdateHighscore()
    {
        int highscore = Score.GetHighscore(GameHandler.getLevel());
        transform.Find("highscoreText").GetComponent<Text>().text = "HIGHSCORE \n " + highscore.ToString();
    }

    public static void HideStatic()
    {
        // aby ukryc wynik podczas wyswietlania gry
        instance.gameObject.SetActive(false);
    }
}

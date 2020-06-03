using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Score
{

    public static event EventHandler OnHighscoreChanged;

    private static int score; // przechowuje wynik

    public static void InitializeStatic()
    {
        OnHighscoreChanged = null;
        score = 0;
        // ustaw punkty na zero
    }

    public static int GetScore()
    {
        // funkcja zwracajaca wynik
        return score;
    }

    public static void AddScore()
    {
        // funkcja zwiekszajaca wynik o 100
        score += 100;
    }


    // funkcja do przywracacania aktualnego najwyzszego wyniku
    public static int GetHighscore(int level)
    {
        // PlayPrefs dziala jak magazyn
        // klucz to highscore a wartosc to 100
        return PlayerPrefs.GetInt("highscore"+level, 0);
    }

    public static bool TrySetNewHighscore(int level)
    {
        return TrySetNewHighscore(score,level);
    }

    public static bool TrySetNewHighscore(int score, int level)
    {
        // spr czy wynik jest nowym najywyzszym wynikiem 
        // jesli tak to zwraca true, jesli nie to false
        int highscore = GetHighscore(level); // uzyskaj obezny wynik
        
        // i spr czy ten wynik jest wyzszy od obecnego najwyzszego wyniku
        if (score > highscore)
        {
            // jesli tak to zastap najlepszy wynik
            PlayerPrefs.SetInt("highscore"+level, score);
            PlayerPrefs.Save();
            if (OnHighscoreChanged != null) OnHighscoreChanged(null, EventArgs.Empty);
            return true;
        } else
        {
            return false;
        }
    }
}

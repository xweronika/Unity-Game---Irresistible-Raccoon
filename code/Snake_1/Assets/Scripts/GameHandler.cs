using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;
    private LevelGrid levelGrid; // siatka poziomow
    [SerializeField] private Snake snake;
    private static int level;

    private void Awake()
    {
        instance = this;
        Score.InitializeStatic();
        Time.timeScale = 1f; // wznowienie czasu gry przez skale czasu
        Score.TrySetNewHighscore(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameHandler.Start");

        //  GameObject snakeHeadGameObject = new GameObject();
        //   SpriteRenderer snakeSpriteRender = snakeHeadGameObject.AddComponent<SpriteRenderer>();
        //   snakeSpriteRender.sprite = GameAssets.i.snakeHeadSprite;

        levelGrid = new LevelGrid(26, 18);
        // tworzymy tutaj siatke gry dla wysokosci i szerokosci 20

        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
        foreach(Vector3Int vector in LevelLayouts.getLayout(level))
        {
            levelGrid.AddObstacle(vector);
        }



        // przycisk testowy
        // CMDebug.ButtonUI(Vector2.zero, "Reload Scene", () =>
        //{
        // jesli klikniemy przycisk to
        //   Loader.Load(Loader.Scene.GameScene);
        // modul ladujacy i wywolaj funkcje ladowania

        //});
    }


    // funkcja do aktualizacji
    private void Update()
    {
        // jesli nacisniemy klawisz ESC zatrzymamy gre
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused())
            {
                GameHandler.ResumeGame();
            }
            else
            {
                GameHandler.PauseGame();
            }
        }
    }

    public static void SnakeDied()
    {
        bool isNewHighscore = Score.TrySetNewHighscore(level);
        //zapisz najwyzszy wynik
        GameOverWindow.ShowStatic(isNewHighscore);
        ScoreWindow.HideStatic();
    }

    // pauzowanie gry

    public static void ResumeGame() // wznow gre
    {
        PauseWindow.HideStatic();
        // ukrywamy okno pauzy po wznowieniu gry
        Time.timeScale = 1f;
        // modyfikator do naszego czasu
        // jesli wynosi 1 to gra sie z powrotem wznowi
    }

    // funkcja do zatrzymania gry
    public static void PauseGame() // pauzuj gre
    {
        PauseWindow.ShowStatic();
        // okno pauzy wyswietla sie statycznie

        Time.timeScale = 0f;
        // modyfikator do naszego czasu
        // jesli wynosi 0 to gra sie wstrzyma
    }

    public static bool IsGamePaused()
    {
        // jesli skala czasu wynosi 0 to zwroc 0
        return Time.timeScale == 0f;
    }

    public static void setLevel(int _level)
    {
        level = _level;
    }

    public static int getLevel()
    {
        return level;
    }
}

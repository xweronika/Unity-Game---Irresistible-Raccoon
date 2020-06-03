using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public static class Loader 
{
    public enum Scene
    {
        GameScene,
        Loading,
        MainMenu
    }
    private static Action loaderCallbackAction;
    public static void Load(Scene scene)
    {
        // Ustaw akcje zwrotna ktora zostanie uruchomiona po zaladowaniu sceny Ladowania
        loaderCallbackAction = () =>
        {
            // Zaladuj scene docelowa gdy ladowana jest scena Ladowania
            SceneManager.LoadScene(scene.ToString());
        };
        // Zaladuj scene Ladowania
        SceneManager.LoadScene(Scene.Loading.ToString());

    }
    public static void LoaderCallback()
    {
        if(loaderCallbackAction != null)
        {
            loaderCallbackAction();
            loaderCallbackAction = null;
        }
    }
}

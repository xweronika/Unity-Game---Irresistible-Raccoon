using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;


public static class SoundManager 
{
    static AudioSource audioSource;
    static AudioSource audioSourceBack;
    public enum Sound
    {
        SnakeDie,
        SnakeEat,
        ButtonClick,
        ButtonMove,
        ButtonQuit,
        BackgroundSound,
        Heart,
        Barrier
    }
    // funkcja do odtworzenia dzwieku

    public static void PlaySound(Sound sound, float volume = 1.0f)
    {
        // tworzymy nowy obiekt gry
        GameObject soundGameObject = new GameObject("Sound");

        // dodajemy komponent zrodla dzwieku
        audioSource = soundGameObject.AddComponent<AudioSource>();
        // uzyskujemy dostep do zrodla dzwiku i wywolujemy funkce PlayOneShot
        // w parametrach potrzebujemy odniesienia klipu audio
        // uzyskujemy dostep do zasobow gry
        audioSource.PlayOneShot(GetAudioClip(sound)); 
    }
    public static void PlayBackground(Sound sound)
    {
        // sprawdza czy obeznie gra muzyka w tle
        if (audioSourceBack.isPlaying == false) 
        {
            // jesli nie to pusc na nowo, zapetlanie
            audioSourceBack.PlayOneShot(GetAudioClip(sound));
        }
    }

    public static void PlaySoundBackground(Sound sound, float volume)
    {
        // to samo tylko do muzyki w tle

        GameObject soundGameObject = new GameObject("Sound");
        audioSourceBack = soundGameObject.AddComponent<AudioSource>();
        audioSourceBack.volume = volume; // glosnosc
        audioSourceBack.PlayOneShot(GetAudioClip(sound));


    }
    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound" + sound + "not found!");
        return null;
    }


    public static void AddButtonSound(this Button_UI buttonUI) // dziweki do przyciskow
    {
        // odtworz dzwiek po najechaniu na przycisk
        buttonUI.MouseOverOnceFunc += () => SoundManager.PlaySound(SoundManager.Sound.ButtonMove);
        buttonUI.ClickFunc += () => SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
    }

    public static void AddButtonQuitSound(this Button_UI buttonUI) // dziweki do przyciskow
    {
        // odtworz dzwiek po najechaniu na przycisk
        buttonUI.MouseOverOnceFunc += () => SoundManager.PlaySound(SoundManager.Sound.ButtonMove);
        buttonUI.ClickFunc += () => SoundManager.PlaySound(SoundManager.Sound.ButtonQuit);
    }

}


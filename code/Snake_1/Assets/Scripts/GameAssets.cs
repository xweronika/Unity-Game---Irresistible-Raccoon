using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameAssets : MonoBehaviour
{

    public static GameAssets i; // umieranie

    private void Awake()
    {
        i = this;
        bodyL.GetComponent<Animator>().speed = 10;

        bodyR.GetComponent<Animator>().speed = 0;

        target.GetComponent<Animator>().speed = 0;
    }

    public Sprite snakeHeadSprite;
    public Sprite foodSprite;
    public Sprite snakeBodySpriteR;
    public Sprite snakeBodySpriteL;
    public Sprite obstacleTree;
    public Sprite obstacleBush;
    public Sprite hpApple;
    public Sprite heart;
    public Sprite heart_e;
    public GameObject bodyL;
    public GameObject bodyR;
    public GameObject target;

    // dzwiek
    public SoundAudioClip[] soundAudioClipArray;

    [Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

}

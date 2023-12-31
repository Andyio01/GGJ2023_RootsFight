using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoPlayBubbleSound : MonoBehaviour {
    private AudioSource audio;

    private void OnEnable() {
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += PlayBubbleSound;
    }

    void PlayBubbleSound(Scene scene, LoadSceneMode mode) { audio.Play(); }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text Best;
    public AudioClip clickerSound;
    private AudioSource playerAudio;
    private void Start()
    {
        Best.text = $"Best Score : {GameManager.Instance.Score} : {GameManager.Instance.TeamName}";
        playerAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAudio.PlayOneShot(clickerSound, 1.0f);
        }
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void InputName(string text)
    {
        GameManager.Instance.Name = text;
    }
    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI perfectText;
    [SerializeField] TextMeshProUGUI greatText;
    [SerializeField] TextMeshProUGUI badText;
    [SerializeField] TextMeshProUGUI missText;

    private void OnEnable()
    {
        scoreText.text = Gmanager.instance.score.ToString();
        perfectText.text = Gmanager.instance.perfect.ToString();
        greatText.text = Gmanager.instance.great.ToString();
        badText.text = Gmanager.instance.bad.ToString();
        missText.text = Gmanager.instance.miss.ToString();

    }

    public void Retry()
    {
        Gmanager.instance.perfect = 0;
        Gmanager.instance.great = 0;
        Gmanager.instance.bad = 0;
        Gmanager.instance.miss = 0;
        Gmanager.instance.maxScore = 0;
        Gmanager.instance.ratioScore = 0;
        Gmanager.instance.score = 0;
        Gmanager.instance.combo = 0;
        SceneManager.LoadScene("MusicScene");
    }

    public void Close()
    {
        Gmanager.instance.perfect = 0;
        Gmanager.instance.great = 0;
        Gmanager.instance.bad = 0;
        Gmanager.instance.miss = 0;
        Gmanager.instance.maxScore = 0;
        Gmanager.instance.ratioScore = 0;
        Gmanager.instance.score = 0;
        Gmanager.instance.combo = 0;
        SceneManager.LoadScene("MusicSelect");
    }
}

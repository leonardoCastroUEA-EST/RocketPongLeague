using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text playerScoreText;
    private int _playerOneScore = 0;
    private int _playerTwoScore = 0;
    [SerializeField] private int _scoreToWin;
    [SerializeField] private GameObject _gameOverscreen;
    [SerializeField] private TMP_Text _playerWinsText;

    public AudioSource scoreSound;

    void Start()
    {
        //SceneManager.LoadScene("GameScene");
        //playerScoreText.text = "0 : 0";
    }
    void Update()
    {
        
    }
    public void AddScore(bool isPlayerOne)
    {
        if (isPlayerOne)
        {
            _playerOneScore = _playerOneScore + 1;
            if (_playerOneScore >= _scoreToWin)
            {
                _playerWinsText.text = "Red Team Wins";
                _gameOverscreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else
        {
            _playerTwoScore = _playerTwoScore + 1;
            if (_playerTwoScore >= _scoreToWin)
            {
                _playerWinsText.text = "Blue Team Wins";
                _gameOverscreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        scoreSound.Play();
        playerScoreText.text = _playerTwoScore.ToString() + " : " + _playerOneScore.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }
}

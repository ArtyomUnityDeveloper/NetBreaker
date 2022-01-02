using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Config params - настраиваемые параметры
    // Range - задаёт диапазон, а в сочетании с SerializeField позволяет работать с ползунком, а не с полем для ввода
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 5000;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // State variables - переменные состояния - мы их не редактируем, просто наблюдаем за их изменением
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false); // это багфикс (бага не было, но на всякий лучше вставлять во все синглтоны эту строку кода)
            Destroy(gameObject); // если gameStatusCount больше 1, уничтожить игровой объект в котором обрабатывается данный скрипт
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start удаляли, но вернём ради вывода очков
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    // далее описан метод который добавляет очки к currentScore
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        // currentScore = currentScore + pointsPerBlockDestroyed и строка описанная выше - одно и тоже
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}

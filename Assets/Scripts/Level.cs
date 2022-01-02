using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // parameters
    [SerializeField] int breakableBlocks; // сериализовали поле не для того чтобы править знач-я, а для того, чтобы их проверять

    // кэшированная ссылка на другой скрипт
    SceneLoader sceneloader;

    // Start is called before the first frame update
    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>(); // подгружаем скрипт в переменную
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0) // условие обеспечивает переход на след-й уровень
        {
            sceneloader.LoadNextScene();
        }
    }
}

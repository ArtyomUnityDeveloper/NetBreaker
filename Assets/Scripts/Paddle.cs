using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Config params
    [SerializeField] float screenWidthInUnits = 16f; // рассчитывается самостоятельно - ширина экрана в ЮНИТИ ВОРЛД ЮНИТС
    [SerializeField] float minX = 1f; // минимальное зн-е X которое - для платформы (для мячика тупо сделаем "стены"-коллайдеры)
    [SerializeField] float maxX = 15f; // максимальное зн-е Y для платформы

    //cached reference 
    GameSession theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y); // задаём исходное положение
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX); // меняем только X координату вектора, в рамках заданных границ
        transform.position = paddlePos; // присваиваем позиции платформы позицию вектора paddlePos
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
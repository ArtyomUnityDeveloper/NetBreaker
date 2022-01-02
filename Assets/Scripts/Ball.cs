using UnityEngine;

public class Ball : MonoBehaviour
{

    // config params
    [SerializeField] Paddle paddle1; // сюда цеплять будем игровой объект Paddle, только я не понял - почему мы не пишем GameObject тип, а пишем типа Paddle - это ведь класс скрипта
    [SerializeField] float xPush = 2f; // ball speed X axis
    [SerializeField] float yPush = 15f; // ball speed Y axis 
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    // state мы их не меняем
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    [SerializeField] Vector2 ballVelocity;

    // cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    // В старте пропишем вычисление paddleToBallVector'a - это вектор-разница между осями вращения мячика и платформы

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) // !+true=false !+false=true - if срабатывает когда в скобках true
        { 
        LockBallToPaddle(); // поэтому, если игра НЕ началась - в скобках срабатывает условие, и работает скрипт по
        LaunchOnMouseClick(); // удержанию мячика на платформе. Запуск мячика совершается 1 раз за уровень. 
        }

        ballVelocity = myRigidbody2D.velocity;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        // вбиваем в память позицию платформы
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        // изменяем позицию шарика
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0.1f, randomFactor), Random.Range(0.1f, randomFactor));
        if(hasStarted) // если hasStarted = true то выполняй следующее
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}

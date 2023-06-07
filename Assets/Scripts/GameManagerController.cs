using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject field; // Ссылка на объект поля 
    public GameObject figures; // Ссылка на объект фигур 
    public GameObject figurePrefab; // Префаб фигуры 

    public Toggle figure1Toggle; // Компонент Toggle для фигуры 1 
    public Toggle figure2Toggle; // Компонент Toggle для фигуры 2 
    public Toggle figure3Toggle; // Компонент Toggle для фигуры 3 

    public InputField minLifeTimeInput; // Компонент InputField для минимального времени жизни 
    public InputField maxLifeTimeInput; // Компонент InputField для максимального времени жизни 
    public InputField minSpawnDelayInput; // Компонент InputField для минимального времени ожидания 
    public InputField maxSpawnDelayInput; // Компонент InputField для максимального времени ожидания 

    private float minLifeTime; // Минимальное время жизни фигуры 
    private float maxLifeTime; // Максимальное время жизни фигуры 
    private float minSpawnDelay; // Минимальное время ожидания 
    private float maxSpawnDelay; // Максимальное время ожидания 

    private float spawnTimer; // Таймер для создания новых фигур 

    private void Start()
    {
        // Задаем начальные значения для компонентов InputField 
        minLifeTimeInput.text = "10";
        maxLifeTimeInput.text = "20";
        minSpawnDelayInput.text = "100";
        maxSpawnDelayInput.text = "200";

        // Получаем значения из компонентов InputField 
        minLifeTime = float.Parse(minLifeTimeInput.text);
        maxLifeTime = float.Parse(maxLifeTimeInput.text);
        minSpawnDelay = float.Parse(minSpawnDelayInput.text);
        maxSpawnDelay = float.Parse(maxSpawnDelayInput.text);

        // Инициализируем таймер для создания новых фигур 
        spawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    private void Update()
    {
        // Уменьшаем таймер для создания новых фигур каждый кадр 
        spawnTimer -= Time.deltaTime;

        // Если таймер дошел до нуля, создаем новую фигуру 
        if (spawnTimer <= 0f)
        {
            // Выбираем случайную фигуру из доступных 
            GameObject selectedFigure = null;
            if (figure1Toggle.isOn)
            {
                selectedFigure = figurePrefab;
            }
            else if (figure2Toggle.isOn)
            {
                selectedFigure = figurePrefab;
            }
            else if (figure3Toggle.isOn)
            {
                selectedFigure = figurePrefab;
            }

            // Создаем новую фигуру на поле 
            GameObject newFigure = Instantiate(selectedFigure, figures.transform);
            newFigure.transform.position = GetRandomPosition();

            // Задаем случайное время жизни для фигуры 
            float lifeTime = Random.Range(minLifeTime, maxLifeTime);
            newFigure.GetComponent<FigureController>().lifeTime = lifeTime;

            // Инициализируем таймер для фигуры 
            newFigure.GetComponent<FigureController>().timer = lifeTime;

            // Сбрасываем таймер для создания новых фигур 
            spawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);
        }
    }

    // Возвращает случайную позицию на поле 
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-field.transform.localScale.x / 2f, field.transform.localScale.x / 2f);
        float z = Random.Range(-field.transform.localScale.z / 2f, field.transform.localScale.z / 2f);
        float y = Random.Range(-field.transform.localScale.y / 2f, field.transform.localScale.y / 2f);
        return new Vector3(x, y, z);
    }

    public void OnInputChange()
    {
        // Получаем новые значения для параметров 
        minLifeTime = float.Parse(minLifeTimeInput.text);
        maxLifeTime = float.Parse(maxLifeTimeInput.text);
        minSpawnDelay = float.Parse(minSpawnDelayInput.text);
        maxSpawnDelay = float.Parse(maxSpawnDelayInput.text);
    }
}

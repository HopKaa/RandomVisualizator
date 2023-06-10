using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject field;
    public GameObject shapePrefab;
    public Toggle circleToggle;
    public Toggle squareToggle;
    public Toggle triangleToggle;
    public InputField minLifeInput;
    public InputField maxLifeInput;
    public InputField minCooldownInput;
    public InputField maxCooldownInput;

    private List<Shape.ShapeType> availableShapes = new List<Shape.ShapeType>();
    private float minLifeTime;
    private float maxLifeTime;
    private float minCooldown;
    private float maxCooldown;
    private float cooldownTimer;

    void Start()
    {
        // Начальная инициализация
        availableShapes.Add(Shape.ShapeType.Circle);
        availableShapes.Add(Shape.ShapeType.Square);
        availableShapes.Add(Shape.ShapeType.Triangle);
        minLifeTime = 1;
        maxLifeTime = 5;
        minCooldown = 0.5f;
        maxCooldown = 2;
        cooldownTimer = 0;
    }

    void Update()
    {
        // Обновление таймера ожидания
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0)
        {
            CreateShape();
            cooldownTimer = Random.Range(minCooldown, maxCooldown);
        }
    }

    public void SetCircle(bool value)
    {
        if (value)
        {
            availableShapes.Remove(Shape.ShapeType.Circle);
            availableShapes.Insert(0, Shape.ShapeType.Circle);
        }
    }

    public void SetSquare(bool value)
    {
        if (value)
        {
            availableShapes.Remove(Shape.ShapeType.Square);
            availableShapes.Insert(0, Shape.ShapeType.Square);
        }
    }

    public void SetTriangle(bool value)
    {
        if (value)
        {
            availableShapes.Remove(Shape.ShapeType.Triangle);
            availableShapes.Insert(0, Shape.ShapeType.Triangle);
        }
    }

    public void SetMinLifeTime(string value)
    {
        float.TryParse(value, out minLifeTime);
    }

    public void SetMaxLifeTime(string value)
    {
        float.TryParse(value, out maxLifeTime);
    }

    public void SetMinCooldown(string value)
    {
        float.TryParse(value, out minCooldown);
    }

    public void SetMaxCooldown(string value)
    {
        float.TryParse(value, out maxCooldown);
    }

    private void CreateShape()
    {
        // Создание фигуры
        Shape.ShapeType type = availableShapes[Random.Range(0, availableShapes.Count)];
        float life = Random.Range(minLifeTime, maxLifeTime);
        float x = Random.Range(-field.transform.localScale.x / 2, field.transform.localScale.x / 2);
        float y = Random.Range(-field.transform.localScale.y / 2, field.transform.localScale.y / 2);
        GameObject shapeObject = Instantiate(shapePrefab, field.transform);
        shapeObject.transform.localPosition = new Vector3(x, y, 0);
        Shape shape = shapeObject.GetComponent<Shape>();
        shape.Initialize(type, life, new Vector2(x, y));
    }
}
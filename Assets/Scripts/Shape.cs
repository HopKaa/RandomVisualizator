using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shape : MonoBehaviour
{
    public enum ShapeType { Circle, Square, Triangle };
    public ShapeType shapeType;
    public float lifeTime;
    public Vector2 fieldPosition;

    private float timer;
    private Text timerText;

    void Start()
    {
        // Выбор спрайта для конкретного типа фигуры
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        switch (shapeType)
        {
            case ShapeType.Circle:
                spriteRenderer.sprite = Resources.Load<Sprite>("Circle");
                break;
            case ShapeType.Square:
                spriteRenderer.sprite = Resources.Load<Sprite>("Square");
                break;
            case ShapeType.Triangle:
                spriteRenderer.sprite = Resources.Load<Sprite>("Triangle");
                break;
        }

        // Создание текста таймера
        GameObject timerObject = new GameObject("Timer");
        timerObject.transform.parent = transform;
        timerObject.transform.localPosition = new Vector3(0, 0, -0.1f);
        timerText = timerObject.AddComponent<Text>();
        timerText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        timerText.fontSize = 20;
        timerText.alignment = TextAnchor.MiddleCenter;
        timerText.color = Color.white;
    }

    void Update()
    {
        // Обновление таймера
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
        timerText.text = timer.ToString("F1");
    }

    public void Initialize(ShapeType type, float life, Vector2 position)
    {
        // Инициализация параметров фигуры
        shapeType = type;
        lifeTime = life;
        fieldPosition = position;
        timer = lifeTime;
    }
}
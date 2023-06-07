using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour
{
    public float lifeTime; // Время жизни фигуры
    public float timer; // Таймер фигуры

    private void Start()
    {
        // Задаем случайное время жизни
        lifeTime = Random.Range(1f, 2f);
        // Инициализируем таймер
        timer = lifeTime;
    }

    private void Update()
    {
        // Уменьшаем таймер фигуры каждый кадр
        timer -= Time.deltaTime;
        // Если таймер дошел до нуля, уничтожаем фигуру
        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}


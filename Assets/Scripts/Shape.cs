using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shape : MonoBehaviour
{
    [SerializeField] private Font timerFont;

    public enum ShapeType { Circle, Square, Triangle };
    public ShapeType shapeType;
    public float lifeTime;

    private float timer;
    private Text timerText;

    void Start()
    {
        GameObject timerObject = new GameObject("Timer");
        timerObject.transform.parent = transform;
        timerObject.transform.localPosition = new Vector3(0, 0, -0.1f);
        timerText = timerObject.AddComponent<Text>();
        timerText.font = timerFont;
        timerText.fontSize = 20;
        timerText.alignment = TextAnchor.MiddleCenter;
        timerText.color = Color.white;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
        timerText.text = timer.ToString("F1");
    }

    public void InitializeFigure(float life, Vector2 position)
    {
        lifeTime = life;
        timer = lifeTime;
    }
}
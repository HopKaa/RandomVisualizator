using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shape : MonoBehaviour
{
    [SerializeField] private Font _timerFont;
    [SerializeField] private Text _timerText;
    public enum ShapeType { Circle, Square, Triangle };
    public ShapeType shapeType;
    
    private float _lifeTime;
    private float _timer;
    //private Text timerText;

    void Start()
    {
        /*GameObject timerObject = new GameObject("Timer");
        timerObject.transform.parent = transform;
        timerObject.transform.localPosition = new Vector3(0, 0, -0.1f);
        timerText = timerObject.AddComponent<Text>();
        timerText.font = timerFont;
        timerText.fontSize = 20;
        timerText.alignment = TextAnchor.MiddleCenter;
        timerText.color = Color.white; */
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            Destroy(gameObject);
        }
        _timerText.text = _timer.ToString("F1");
    }

    public void InitializeFigure(float life, Vector2 position)
    {
        _lifeTime = life;
        _timer = _lifeTime;
    }
}
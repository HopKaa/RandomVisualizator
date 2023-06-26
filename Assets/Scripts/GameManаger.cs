using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _field;
    [SerializeField] private GameObject _circlePrefab;
    [SerializeField] private GameObject _squarePrefab;
    [SerializeField] private GameObject _trianglePrefab;
    [SerializeField] private Toggle _circleToggle;
    [SerializeField] private Toggle _squareToggle;
    [SerializeField] private Toggle _triangleToggle;
    [SerializeField] private InputField _minLifeInput;
    [SerializeField] private InputField _maxLifeInput;
    [SerializeField] private InputField _minCooldownInput;
    [SerializeField] private InputField _maxCooldownInput;
    [SerializeField] private List<Shape.ShapeType> availableShapes = new List<Shape.ShapeType>();
    private float _minLifeTime;
    private float _maxLifeTime;
    private float _minCooldown;
    private float _maxCooldown;
    private float _cooldownTimer;

    void Start()
    {
        availableShapes.Add(Shape.ShapeType.Square);
        availableShapes.Add(Shape.ShapeType.Circle);
        availableShapes.Add(Shape.ShapeType.Triangle);
        _minLifeTime = 0;
        _maxLifeTime = 0;
        _minCooldown = 0.5f;
        _maxCooldown = 2;
        _cooldownTimer = 0;
    }

    void Update()
    {
        _cooldownTimer -= Time.deltaTime;
        if (_cooldownTimer < 0)
        {
            CreateShape();
            _cooldownTimer = Random.Range(_minCooldown, _maxCooldown);
        }
    }

    public void SetMinLifeTime()
    {
        float.TryParse(_minLifeInput.text, out _minLifeTime);
    }

    public void SetMaxLifeTime()
    {
        float.TryParse(_maxLifeInput.text, out _maxLifeTime);
    }

    public void SetMinCooldown()
    {
        float.TryParse(_minCooldownInput.text, out _minCooldown);
    }

    public void SetMaxCooldown()
    {
        float.TryParse(_maxCooldownInput.text, out _maxCooldown);
    }

    private void CreateShape()
    {
        Debug.Log(_minLifeTime.ToString() + " " + _maxLifeTime.ToString() );
        float life = Random.Range(_minLifeTime, _maxLifeTime);
        float x = Random.Range(-_field.transform.localScale.x / 800, _field.transform.localScale.x / 800);
        float y = Random.Range(-_field.transform.localScale.y / 800, _field.transform.localScale.y / 800);
  
        GameObject shapeObject = Instantiate(GetRandomFigurePrefab(), _field.transform);
        shapeObject.transform.localPosition = new Vector3(x, y, 0);
        Shape shape = shapeObject.GetComponent<Shape>();
        shape.InitializeFigure(life, new Vector2(x, y));
    }
    private GameObject GetRandomFigurePrefab()
    {
        Shape.ShapeType type = availableShapes[Random.Range(0, availableShapes.Count)];

        switch (type)
        {
            case Shape.ShapeType.Circle:
                if (!_circleToggle.isOn)
                {
                    return null;
                }
                return _circlePrefab;
            case Shape.ShapeType.Square:
                if (!_squareToggle.isOn)
                {
                    return null;
                }
                return _squarePrefab;
            case Shape.ShapeType.Triangle:
                if (!_triangleToggle.isOn)
                {
                    return null;
                }
                return _trianglePrefab;
            default:
                return null;
        }
    }
}
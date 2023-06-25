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
    private float minLifeTime;
    private float maxLifeTime;
    private float minCooldown;
    private float maxCooldown;
    private float cooldownTimer;

    void Start()
    {
        availableShapes.Add(Shape.ShapeType.Square);
        availableShapes.Add(Shape.ShapeType.Circle);
        availableShapes.Add(Shape.ShapeType.Triangle);
        minLifeTime = 0;
        maxLifeTime = 0;
        minCooldown = 0.5f;
        maxCooldown = 2;
        cooldownTimer = 0;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0)
        {
            CreateShape();
            cooldownTimer = Random.Range(minCooldown, maxCooldown);
        }
    }

    public void SetMinLifeTime()
    {
        float.TryParse(_minLifeInput.text, out minLifeTime);
    }

    public void SetMaxLifeTime()
    {
        float.TryParse(_maxLifeInput.text, out maxLifeTime);
    }

    public void SetMinCooldown()
    {
        float.TryParse(_minCooldownInput.text, out minCooldown);
    }

    public void SetMaxCooldown()
    {
        float.TryParse(_maxCooldownInput.text, out maxCooldown);
    }

    private void CreateShape()
    {
        Debug.Log(minLifeTime.ToString() + " " + maxLifeTime.ToString() );
        float life = Random.Range(minLifeTime, maxLifeTime);
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
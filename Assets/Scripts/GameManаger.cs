using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject field;
    public GameObject circlePrefab;
    public GameObject squarePrefab;
    public GameObject trianglePrefab;
    public Toggle circleToggle;
    public Toggle squareToggle;
    public Toggle triangleToggle;
    public InputField minLifeInput;
    public InputField maxLifeInput;
    public InputField minCooldownInput;
    public InputField maxCooldownInput;

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

        float life = Random.Range(minLifeTime, maxLifeTime);
        float x = Random.Range(-field.transform.localScale.x / 800, field.transform.localScale.x / 800);
        float y = Random.Range(-field.transform.localScale.y / 800, field.transform.localScale.y / 800);
  
        GameObject shapeObject = Instantiate(GetRandomFigurePrefab(), field.transform);
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
                if (!circleToggle.isOn)
                {
                    return null;
                }
                return circlePrefab;
            case Shape.ShapeType.Square:
                if (!squareToggle.isOn)
                {
                    return null;
                }
                return squarePrefab;
            case Shape.ShapeType.Triangle:
                if (!triangleToggle.isOn)
                {
                    return null;
                }
                return trianglePrefab;
            default:
                return null;
        }
    }
}
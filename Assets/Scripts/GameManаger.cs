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
    [SerializeField] private List<ShapeSettings> _availableShapes = new ();
    private float _minLifeTime;
    private float _maxLifeTime;
    private float _minCooldown;
    private float _maxCooldown;
    private float _cooldownTimer;
    private const int FieldWidth = 800;
    private const int FieldHight = 800;

    private void Start()
    {
        _availableShapes.Add(new ShapeSettings(_squareToggle, _squarePrefab));
        _availableShapes.Add(new ShapeSettings(_circleToggle, _circlePrefab));
        _availableShapes.Add(new ShapeSettings(_triangleToggle, _squarePrefab));
        _minLifeTime = 1;
        _maxLifeTime = 2;
        _minCooldown = 1;
        _maxCooldown = 2;
    }

    private void Update()
    {
        _cooldownTimer -= Time.deltaTime;
        if (_cooldownTimer <= 0)
        {
            CreateShape();
            _cooldownTimer += Random.Range(_minCooldown, _maxCooldown);
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
        float x = Random.Range(-_field.transform.localScale.x / FieldWidth, _field.transform.localScale.x / FieldWidth);
        float y = Random.Range(-_field.transform.localScale.y / FieldHight, _field.transform.localScale.y / FieldHight);
  
        GameObject shapeObject = Instantiate(GetRandomFigurePrefab(), _field.transform);
        Shape shape = shapeObject.GetComponent<Shape>();
        shape.InitializeFigure(life, new Vector3(x, y, 0));
    }
    private GameObject GetRandomFigurePrefab()
    {
        ShapeSettings settings = _availableShapes[Random.Range(0, _availableShapes.Count)];

        return settings.Prefab;
    }
}
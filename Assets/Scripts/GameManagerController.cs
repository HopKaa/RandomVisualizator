using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject field; // ������ �� ������ ���� 
    public GameObject figures; // ������ �� ������ ����� 
    public GameObject figurePrefab; // ������ ������ 

    public Toggle figure1Toggle; // ��������� Toggle ��� ������ 1 
    public Toggle figure2Toggle; // ��������� Toggle ��� ������ 2 
    public Toggle figure3Toggle; // ��������� Toggle ��� ������ 3 

    public InputField minLifeTimeInput; // ��������� InputField ��� ������������ ������� ����� 
    public InputField maxLifeTimeInput; // ��������� InputField ��� ������������� ������� ����� 
    public InputField minSpawnDelayInput; // ��������� InputField ��� ������������ ������� �������� 
    public InputField maxSpawnDelayInput; // ��������� InputField ��� ������������� ������� �������� 

    private float minLifeTime; // ����������� ����� ����� ������ 
    private float maxLifeTime; // ������������ ����� ����� ������ 
    private float minSpawnDelay; // ����������� ����� �������� 
    private float maxSpawnDelay; // ������������ ����� �������� 

    private float spawnTimer; // ������ ��� �������� ����� ����� 

    private void Start()
    {
        // ������ ��������� �������� ��� ����������� InputField 
        minLifeTimeInput.text = "10";
        maxLifeTimeInput.text = "20";
        minSpawnDelayInput.text = "100";
        maxSpawnDelayInput.text = "200";

        // �������� �������� �� ����������� InputField 
        minLifeTime = float.Parse(minLifeTimeInput.text);
        maxLifeTime = float.Parse(maxLifeTimeInput.text);
        minSpawnDelay = float.Parse(minSpawnDelayInput.text);
        maxSpawnDelay = float.Parse(maxSpawnDelayInput.text);

        // �������������� ������ ��� �������� ����� ����� 
        spawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    private void Update()
    {
        // ��������� ������ ��� �������� ����� ����� ������ ���� 
        spawnTimer -= Time.deltaTime;

        // ���� ������ ����� �� ����, ������� ����� ������ 
        if (spawnTimer <= 0f)
        {
            // �������� ��������� ������ �� ��������� 
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

            // ������� ����� ������ �� ���� 
            GameObject newFigure = Instantiate(selectedFigure, figures.transform);
            newFigure.transform.position = GetRandomPosition();

            // ������ ��������� ����� ����� ��� ������ 
            float lifeTime = Random.Range(minLifeTime, maxLifeTime);
            newFigure.GetComponent<FigureController>().lifeTime = lifeTime;

            // �������������� ������ ��� ������ 
            newFigure.GetComponent<FigureController>().timer = lifeTime;

            // ���������� ������ ��� �������� ����� ����� 
            spawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);
        }
    }

    // ���������� ��������� ������� �� ���� 
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-field.transform.localScale.x / 2f, field.transform.localScale.x / 2f);
        float z = Random.Range(-field.transform.localScale.z / 2f, field.transform.localScale.z / 2f);
        float y = Random.Range(-field.transform.localScale.y / 2f, field.transform.localScale.y / 2f);
        return new Vector3(x, y, z);
    }

    public void OnInputChange()
    {
        // �������� ����� �������� ��� ���������� 
        minLifeTime = float.Parse(minLifeTimeInput.text);
        maxLifeTime = float.Parse(maxLifeTimeInput.text);
        minSpawnDelay = float.Parse(minSpawnDelayInput.text);
        maxSpawnDelay = float.Parse(maxSpawnDelayInput.text);
    }
}

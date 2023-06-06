using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour
{
    public float lifeTime; // ����� ����� ������
    public float timer; // ������ ������

    private void Start()
    {
        // ������ ��������� ����� �����
        lifeTime = Random.Range(2f, 5f);
        // �������������� ������
        timer = lifeTime;
    }

    private void Update()
    {
        // ��������� ������ ������ ������ ����
        timer -= Time.deltaTime;
        // ���� ������ ����� �� ����, ���������� ������
        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}


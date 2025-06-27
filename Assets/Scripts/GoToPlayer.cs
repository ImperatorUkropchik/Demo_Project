using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayer : MonoBehaviour
{
    public Transform player;          // ���� ����� ��������� ������ ����� ���������
    public float moveSpeed = 10f;      // �������� ��������
    private bool need = false;

    private Vector2 direction;

    void Start()
    {
        Invoke("Pereka", 1.5f);
        if (player != null)
        {
            // ����������� � ������ (���������������, ����� ��������� ���������� ��������)
            direction = (player.position - transform.position).normalized;
        }
        else
        {
            Debug.LogWarning("Player �� �������� � ����������!");
        }
    }
    private void Pereka()
    {
        need = true;
    }

    void Update()
    {
        if (player != null)
        {
            if (need)
            {
                // ��������� � ������� ������ �� �����������, ������������ ���� ��� � Start
                transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
            }
            if(transform.position.y >= player.transform.position.y)
            {
                Debug.Log("gdg");
                need = false;
            }

        }
    }
}

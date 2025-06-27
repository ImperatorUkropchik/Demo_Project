using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayer : MonoBehaviour
{
    public Transform player;          // Сюда нужно привязать игрока через инспектор
    public float moveSpeed = 10f;      // Скорость движения
    private bool need = false;

    private Vector2 direction;

    void Start()
    {
        Invoke("Pereka", 1.5f);
        if (player != null)
        {
            // Направление к игроку (нормализованное, чтобы сохранять постоянную скорость)
            direction = (player.position - transform.position).normalized;
        }
        else
        {
            Debug.LogWarning("Player не назначен в инспекторе!");
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
                // Двигаемся в сторону игрока по направлению, вычисленному один раз в Start
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

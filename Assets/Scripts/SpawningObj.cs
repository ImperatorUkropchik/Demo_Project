using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class SpawningObj : MonoBehaviour
{
    public GameObject Coin;  // Объект, который нужно заспавнить
    public GameObject Ammo;
    public Tilemap tilemap;           // Ссылка на Tilemap (установить в инспекторе)

    private void Start()
    {
        InvokeRepeating("SpawnOffScreen", 0, 2);
    }
    public void SpawnOffScreen()
    {
        //Debug.Log("suka");
        // Получаем главную камеру
        Camera cam = Camera.main;

        // Получаем координаты углов экрана в мировом пространстве
        Vector3 minScreen = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)); // нижний левый угол
        Vector3 maxScreen = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)); // верхний правый угол

        // Создаём прямоугольник, представляющий видимую область камеры
        Rect screenRect = new Rect(
            minScreen.x,
            minScreen.y,
            maxScreen.x - minScreen.x,
            maxScreen.y - minScreen.y
        );

        // Список всех возможных позиций, где можно заспавнить объект вне камеры
        List<Vector3> possiblePositions = new List<Vector3>();

        // Проходим по всем ячейкам в пределах размеров tilemap
        foreach (Vector3Int cellPos in tilemap.cellBounds.allPositionsWithin)
        {
            // Проверяем, есть ли тайл в данной ячейке
            if (tilemap.HasTile(cellPos))
            {
                // Получаем мировую позицию центра тайла
                Vector3 worldPos = tilemap.GetCellCenterWorld(cellPos);

                // Проверяем, чтобы позиция НЕ находилась в пределах экрана
                if (!screenRect.Contains(worldPos))
                {
                    // Добавляем в список возможных позиций
                    possiblePositions.Add(worldPos);
                }
            }
        }

        // Если не нашлось ни одной подходящей позиции — выводим предупреждение
        if (possiblePositions.Count == 0)
        {
            Debug.LogWarning("Нет подходящих тайлов вне экрана для спавна.");
            return;
        }

        // Выбираем случайную позицию из списка
        Vector3 spawnPos = possiblePositions[Random.Range(0, possiblePositions.Count)];
        float witchObjSpawn;
        witchObjSpawn = Random.Range(0, 2);
        // Спавним объект в выбранной позиции
        if(witchObjSpawn == 0)
        {
            Instantiate(Coin, spawnPos, Quaternion.identity);
        }
        if (witchObjSpawn == 1)
        {
            Instantiate(Ammo, spawnPos, Quaternion.identity);
        }
    }
}



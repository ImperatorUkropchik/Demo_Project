using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class SpawningObj : MonoBehaviour
{
    public GameObject Coin;  // ������, ������� ����� ����������
    public GameObject Ammo;
    public Tilemap tilemap;           // ������ �� Tilemap (���������� � ����������)

    private void Start()
    {
        InvokeRepeating("SpawnOffScreen", 0, 2);
    }
    public void SpawnOffScreen()
    {
        //Debug.Log("suka");
        // �������� ������� ������
        Camera cam = Camera.main;

        // �������� ���������� ����� ������ � ������� ������������
        Vector3 minScreen = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)); // ������ ����� ����
        Vector3 maxScreen = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)); // ������� ������ ����

        // ������ �������������, �������������� ������� ������� ������
        Rect screenRect = new Rect(
            minScreen.x,
            minScreen.y,
            maxScreen.x - minScreen.x,
            maxScreen.y - minScreen.y
        );

        // ������ ���� ��������� �������, ��� ����� ���������� ������ ��� ������
        List<Vector3> possiblePositions = new List<Vector3>();

        // �������� �� ���� ������� � �������� �������� tilemap
        foreach (Vector3Int cellPos in tilemap.cellBounds.allPositionsWithin)
        {
            // ���������, ���� �� ���� � ������ ������
            if (tilemap.HasTile(cellPos))
            {
                // �������� ������� ������� ������ �����
                Vector3 worldPos = tilemap.GetCellCenterWorld(cellPos);

                // ���������, ����� ������� �� ���������� � �������� ������
                if (!screenRect.Contains(worldPos))
                {
                    // ��������� � ������ ��������� �������
                    possiblePositions.Add(worldPos);
                }
            }
        }

        // ���� �� ������� �� ����� ���������� ������� � ������� ��������������
        if (possiblePositions.Count == 0)
        {
            Debug.LogWarning("��� ���������� ������ ��� ������ ��� ������.");
            return;
        }

        // �������� ��������� ������� �� ������
        Vector3 spawnPos = possiblePositions[Random.Range(0, possiblePositions.Count)];
        float witchObjSpawn;
        witchObjSpawn = Random.Range(0, 2);
        // ������� ������ � ��������� �������
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



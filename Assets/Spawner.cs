using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float spawnTime = 0;

    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime > 0.1f)
        {
            Spawn();
            spawnTime = 0;
        }
    }
    void Spawn()
    {
        int ranMonsterID = Random.Range(0, GameManager.instance.poolManager.prefabs.Length);
        GameObject enemy = GameManager.instance.poolManager.Get(ranMonsterID);
        enemy.transform.position = Vector3.zero; // 예시로 위치 설정
    }
}

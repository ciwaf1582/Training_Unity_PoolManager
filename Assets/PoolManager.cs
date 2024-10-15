using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    List<GameObject>[] pools;
    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
        Debug.Log(pools.Length);
    }
    public GameObject Get(int index)
    {
        GameObject select = null;

        // ... 선택한 풀의 비활성화된 게임 오브젝트 접근
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                //... 발견하면 select 변수에 할당
                select = item;
                select.transform.position = new Vector3(0, 0.5f, 0);
                select.SetActive(true);
                return select;
            }
        }
        // 활성화된 오브젝트가 없으면 새로 생성
        select = Instantiate(prefabs[index], transform);
        pools[index].Add(select);
        Debug.Log("소환...!");
        return select;
    }
}

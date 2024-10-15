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

        // ... ������ Ǯ�� ��Ȱ��ȭ�� ���� ������Ʈ ����
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                //... �߰��ϸ� select ������ �Ҵ�
                select = item;
                select.transform.position = new Vector3(0, 0.5f, 0);
                select.SetActive(true);
                return select;
            }
        }
        // Ȱ��ȭ�� ������Ʈ�� ������ ���� ����
        select = Instantiate(prefabs[index], transform);
        pools[index].Add(select);
        Debug.Log("��ȯ...!");
        return select;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    public GameObject arrowPrefab;
    public GameObject monsterPrefab;
    public int poolSize = 300;
    
    // ������Ʈ Ǯ�� ������ ��ųʸ�
    private Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();




    void Start()
    {
        CreatePool("Arrow", arrowPrefab);
        CreatePool("Monster",  monsterPrefab);
    }

    private void Update()
    {
        
    }

    // Ǯ ���� �޼���
    private void CreatePool(string key, GameObject prefab)
    {
        if(!pools.ContainsKey(key))
        {
            List<GameObject> pool = new List<GameObject>();

            for ( int i = 0; i < poolSize; i++ )
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                pool.Add(obj);
            }

            pools.Add(key, pool);
        }
    }

    // �����ִ� ���ӿ�����Ʈ�� ã�� activ�� ���·� �����ϰ� return�Ѵ�.
    public GameObject Get(string key)
    {
        if (pools.ContainsKey(key))
        {
            List< GameObject> pool = pools[key];

            foreach (GameObject obj in pool )
            {
                if(!obj.activeSelf)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            // ���� ����
            GameObject newObj = Instantiate(pool[0]);
            newObj.SetActive(true);
            pool.Add(newObj);
            return newObj;
        }
        // Ű���� �߸� �Ǿ��� ��� ��ȯ
        return null; 
    }

    public void Release(string key, GameObject obj)
    {
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
        if(pools.ContainsKey(key))
        {
            obj.SetActive(false);
        }
    }
}

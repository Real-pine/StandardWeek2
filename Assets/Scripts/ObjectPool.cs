using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    public GameObject arrowPrefab;
    public GameObject monsterPrefab;
    public int poolSize = 300;
    
    // 오브젝트 풀을 관리할 딕셔너리
    private Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();




    void Start()
    {
        CreatePool("Arrow", arrowPrefab);
        CreatePool("Monster",  monsterPrefab);
    }

    private void Update()
    {
        
    }

    // 풀 생성 메서드
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

    // 꺼져있는 게임오브젝트를 찾아 activ한 상태로 변경하고 return한다.
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

            // 새로 생산
            GameObject newObj = Instantiate(pool[0]);
            newObj.SetActive(true);
            pool.Add(newObj);
            return newObj;
        }
        // 키값이 잘못 되었을 경우 반환
        return null; 
    }

    public void Release(string key, GameObject obj)
    {
        // 게임오브젝트를 deactive한다.
        if(pools.ContainsKey(key))
        {
            obj.SetActive(false);
        }
    }
}

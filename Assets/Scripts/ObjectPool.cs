using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
      public GameObject prefab;
    public int poolSize = 300;
    private List<GameObject> pool = new List<GameObject>();




    void Start()
    {
        // 미리 poolSize만큼 게임오브젝트를 생성한다.
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }

        
    }

    public GameObject Get()
    {
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.
       foreach(GameObject obj in pool)
        {
            if(!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        
    }

    public void Release(GameObject obj)
    {
        // 게임오브젝트를 deactive한다.
        obj.SetActive(false);
    }
}

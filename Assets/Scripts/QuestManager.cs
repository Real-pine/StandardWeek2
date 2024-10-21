using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [구현사항 1] 정적 필드 정의
    private static QuestManager instance;

    // [구현사항 2] 정적 프로퍼티 정의
    public static QuestManager Instance
    {
        get
        {
            if(instance == null)
            {
                // 인스턴스 찾기
                instance = FindObjectOfType<QuestManager>();

                if(instance == null )
                // 인스턴스가 null이라면 새 게임 오브젝트 생성해 추가
                {
                    GameObject questManagerObject = new GameObject("QuestManager");
                    instance = questManagerObject.AddComponent<QuestManager>();
                }
            }
            return instance;
        }
    }

    // [구현사항 3] 인스턴스 검사 로직
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // 씬 변경시 데이터 잃지않고 싱글톤오브젝트 남기기
            DontDestroyOnLoad(gameObject);
        }
        else if ( instance != this ) 
        {
            Destroy(gameObject);          
        }
    }
}

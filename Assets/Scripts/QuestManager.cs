using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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

    public List<QuestDataSO> Quests;

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

    private void Start()
    {
        CreateQuests();
    }

    private void CreateQuests()
    {
        for(int i = 0; i < Quests.Count; i++)
        {
            QuestDataSO quest = Quests[i];
            string questInfo = $"Quest {i + 1} - {quest.QuestName} (최소 레벨 {quest.QuestRequiredLevel})";

            // MonsterQuestDataSO의 경우
            if (quest is MonsterQuestDataSO monsterQuest)
            {
                questInfo += $"\n{monsterQuest.monsterKillCount}마리 소탕";
            }
            // EncounterQuestDataSO의 경우
            else if (quest is EncounterQuestDataSO encounterQuest)
            {
                questInfo += $"\n제한시간 {encounterQuest.timeLimit}분 내에 완료하기";
            }

            Debug.Log(questInfo);
        }
    }
}

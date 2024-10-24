using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor.SceneManagement;
using UnityEngine;



public class QuestManager : MonoBehaviour
{
    // [�������� 1] ���� �ʵ� ����
    private static QuestManager instance;

    // [�������� 2] ���� ������Ƽ ����
    public static QuestManager Instance
    {
        get
        {
            if(instance == null)
            {
                // �ν��Ͻ� ã��
                instance = FindObjectOfType<QuestManager>();

                if(instance == null )
                // �ν��Ͻ��� null�̶�� �� ���� ������Ʈ ������ �߰�
                {
                    GameObject questManagerObject = new GameObject("QuestManager");
                    instance = questManagerObject.AddComponent<QuestManager>();
                }
            }
            return instance;
        }
    }

    public List<QuestDataSO> Quests;

    // [�������� 3] �ν��Ͻ� �˻� ����
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // �� ����� ������ �����ʰ� �̱��������Ʈ �����
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
            string questInfo = $"Quest {i + 1} - {quest.QuestName} (�ּ� ���� {quest.QuestRequiredLevel})";

            // MonsterQuestDataSO�� ���
            if (quest is MonsterQuestDataSO monsterQuest)
            {
                questInfo += $"\n{monsterQuest.monsterKillCount}���� ����";
            }
            // EncounterQuestDataSO�� ���
            else if (quest is EncounterQuestDataSO encounterQuest)
            {
                questInfo += $"\n���ѽð� {encounterQuest.timeLimit}�� ���� �Ϸ��ϱ�";
            }

            Debug.Log(questInfo);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
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
}

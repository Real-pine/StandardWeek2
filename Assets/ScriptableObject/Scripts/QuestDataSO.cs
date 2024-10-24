using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDataSO", menuName = "Custom/QuestData/Default", order= 0)]
public class QuestDataSO : ScriptableObject
{
    // ����Ʈ �̸�
    public string QuestName;
    // ����Ʈ�� �ּ� ����
    public int QuestRequiredLevel;
    // ����Ʈ�� �ִ�  NPC�� id
    public int QuestNPC;
    // ���� ����Ʈ�� id���� ����Ʈ
    public List<int> QuestPrerequisites;
}

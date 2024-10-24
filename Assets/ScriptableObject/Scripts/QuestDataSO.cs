using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDataSO", menuName = "Custom/QuestData/Default", order= 0)]
public class QuestDataSO : ScriptableObject
{
    // 퀘스트 이름
    public string QuestName;
    // 퀘스트의 최소 레벨
    public int QuestRequiredLevel;
    // 퀘스트를 주는  NPC의 id
    public int QuestNPC;
    // 선행 퀘스트의 id들의 리스트
    public List<int> QuestPrerequisites;
}

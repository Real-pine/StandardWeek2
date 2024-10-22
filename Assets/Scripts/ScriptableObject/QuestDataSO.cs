using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDataSO", menuName = "Custom/QuestData", order= 0)]
public class QuestDataSO : ScriptableObject
{
    public string QuestName;
    public int QuestRequiredLevel;
    public int QuestNPC;
    public List<int> QuestPrerequisites;
}

using UnityEngine;

[CreateAssetMenu(fileName = "MonsterQuestDataSO", menuName = "Custom/QuestData/Monster", order = 1)]
public class MonsterQuestDataSO : QuestDataSO
{
    // 몬스터 처치 수
    public int monsterKillCount;
}

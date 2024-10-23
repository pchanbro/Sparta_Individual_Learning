using UnityEngine;

[CreateAssetMenu(fileName = "AchievementSO", menuName = "AchievementData", order = 0)]
public class AchievementSO : ScriptableObject //  이걸 상속받았다
{
    public int threshold;
    public string displayName;
    public string displayDesc;
    public bool isUnlocked;
}
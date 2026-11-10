using System;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    private float currentExp = 0, requiredExp = 100;
    public float CurrentExp => currentExp;
    public float RequiredExp => requiredExp;
    private int level = 1;
    public int Level => level;
    public event Action<float, int> OnExperienceChanged;
    public event Action<int> OnLevelUp;
    public void AddExp(int amount)
    {
        currentExp += amount;
        while (CheckLevelUp())
            LevelUp();
        OnExperienceChanged?.Invoke(currentExp, level);
    }
    private bool CheckLevelUp()
    {
        return currentExp >= requiredExp;
    }
    private void LevelUp()
    {
        level++;
        currentExp -= requiredExp;

        OnLevelUp?.Invoke(level);
    }
}

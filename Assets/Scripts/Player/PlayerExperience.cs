using System;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    private float currentExp = 0, requiredExp = 100;
    private int level = 1;
    public float CurrentExp => currentExp;
    public float RequiredExp => requiredExp;
    public int Level => level;
    public event Action OnExperienceChanged;
    public void AddExp(int amount)
    {
        currentExp += amount;
        while (CheckLevelUp())
            LevelUp();
        OnExperienceChanged?.Invoke();
        Debug.Log("현재 경험치 : " + currentExp + " 현재 레벨 : " + level);
    }
    private bool CheckLevelUp()
    {
        return currentExp >= requiredExp;
    }
    private void LevelUp()
    {
        level++;
        currentExp -= requiredExp;
    }
}

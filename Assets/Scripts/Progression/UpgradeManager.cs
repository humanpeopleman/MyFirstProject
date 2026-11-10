using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] PlayerHealth playerHealth;
    public void ApplyUpgrade(int index)
    {
        switch (index)
        {
            case 0:
                playerAttack.IncreaseDamage(5);
                break;
            case 1:
                playerAttack.ReduceCooldown(0.05f);
                break;
            case 2:
                playerHealth.IncreaseMaxHealth(20);
                break;
        }
    }
}

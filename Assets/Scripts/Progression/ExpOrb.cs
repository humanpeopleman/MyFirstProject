using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    private PlayerExperience playerExp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerExp == null)
                playerExp = collision.GetComponent<PlayerExperience>();
            if (playerExp == null)
                return;
            playerExp.AddExp(250);
            Destroy(gameObject);
        }
    }
}

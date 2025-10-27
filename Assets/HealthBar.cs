using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private PlayerControls player;
    public Image health;

    void Start()
    {
        if(player == null)
        {
            player = FindAnyObjectByType<PlayerControls>();
        }       
    }

    void Update()
    {
        if (player != null && health != null)
        {
            float fill = player.player.getHealth() / player.player.getMaxHealth();
            health.fillAmount = fill;
        }
    }
}

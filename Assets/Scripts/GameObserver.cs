using UnityEngine;
using UnityEngine.SceneManagement;
public class GameObserver : MonoBehaviour
{
    private PlayerControls player;
    private float timer = 0.5f;
    void Start()
    {
        player = FindAnyObjectByType<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.player.isDead())
        {
            player.player.takeDamage(0.02f);
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadSceneAsync(1);
            }
        }
    }
}

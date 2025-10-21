using Unity.VisualScripting;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManagers.instance.NextLevel();
        }
        
    }
}

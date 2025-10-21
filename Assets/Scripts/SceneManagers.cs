using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagers : MonoBehaviour
{
    public static SceneManagers instance;
    [SerializeField] private int[] Levels = { 2, 3 };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);        
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void NextLevel()
    {
        int randIndex = Random.Range(0, Levels.Length);
        SceneManager.LoadSceneAsync(Levels[randIndex]);
    }

    public void LoadLevel(int num)
    {
        SceneManager.LoadSceneAsync(num);
    }
}
using UnityEngine;

public class PlayerHurtbox : MonoBehaviour
{
    private PlayerClass player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<PlayerClass>();
    }

    // Update is called once per frame

}

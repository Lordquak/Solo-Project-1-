using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathField : MonoBehaviour
{
    [SerializeField] private float DeathField = 25f;
    [SerializeField] private string sceneToLoad = "GameOverScene";

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Breaker");
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < DeathField)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, DeathField);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathField : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "GameOverScene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Breaker"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, GetComponent<CapsuleCollider>().radius);
    }


}

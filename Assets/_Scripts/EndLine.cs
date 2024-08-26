using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLine : MonoBehaviour
{
    [SerializeField] GameObject whiteCircle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Finish());
            
            
        }
    }

    IEnumerator Finish()
    {
        GameManager.Instance.isGameOver = true;
        whiteCircle.SetActive(false);
        CameraFollow.Instance.GetComponent<CameraFollow>().enabled = false;
        
        PlayerMovement.Instance.animator.enabled = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}

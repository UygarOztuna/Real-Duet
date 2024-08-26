using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] int ballIndex;
    private ParticleSystem explosionFx;
   
    void Start()
    {
        explosionFx = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

   
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.isGameOver = true;
            explosionFx.Play();

            Splatters.Instance.AddSplatter(collision.transform, collision.contacts[0].point, ballIndex);

            PlayerMovement.Instance.Restart();
            
        }
    }
}

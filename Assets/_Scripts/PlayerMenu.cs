using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
}

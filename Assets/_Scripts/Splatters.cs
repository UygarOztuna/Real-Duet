using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splatters : MonoBehaviour
{
    public static Splatters Instance;

    [SerializeField] private Color[] colors = new Color[2];
    [SerializeField] private GameObject splatterPrefab;
    [SerializeField] private Sprite[] splatterSprites;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
    }

    public void AddSplatter(Transform obstacle, Vector3 pos, int colorIndex)
    {
        GameObject splatter = Instantiate(splatterPrefab, pos, Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-320f, 320f))), obstacle);
        SpriteRenderer sr = splatter.GetComponent<SpriteRenderer>();
        sr.color = colors[colorIndex];
        sr.sprite = splatterSprites[Random.Range(0, splatterSprites.Length)];
    }

}

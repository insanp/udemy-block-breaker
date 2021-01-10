using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    // cached reference
    Level level;

    void Start()
    {
        Debug.Log("hai");
        level = FindObjectOfType<Level>();
        level.AddCountTotalBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.DecreaseTotalBlocks();
        Destroy(gameObject);
    }
}

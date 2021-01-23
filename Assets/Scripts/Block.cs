using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] int score;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHP;

    // cached reference
    Level level;

    // state variables
    [SerializeField] int currentHP;

    void Start()
    {
        level = FindObjectOfType<Level>();
        if (IsBreakable())
        {
            level.AddCountTotalBreakableBlocks();
        }
        currentHP = maxHP;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsBreakable())
        {
            currentHP--;
            if (currentHP <= 0)
            {
                DestroyBlock();
            }
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.DecreaseTotalBlocks();
        FindObjectOfType<GameStatus>().AddScore(score);
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private bool IsBreakable()
    {
        return (tag == "Breakable");
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}

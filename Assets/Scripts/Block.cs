using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] int score;
    [SerializeField] GameObject blockSparklesVFX;

    // cached reference
    Level level;
    GameStatus gameStatus;

    void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        if (IsBreakable())
        {
            level.AddCountTotalBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsBreakable())
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.DecreaseTotalBlocks();
        gameStatus.AddScore(score);
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

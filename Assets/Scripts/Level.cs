using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int totalBreakableBlocks; // serialized for debugging

    private SceneLoader sceneLoader;

    public void Awake()
    {
        Debug.Log("Level Initialize");
        totalBreakableBlocks = 0;
    }

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void AddCountTotalBreakableBlocks()
    {
        totalBreakableBlocks++;
    }

    public void DecreaseTotalBlocks()
    {
        totalBreakableBlocks--;
        if (totalBreakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}

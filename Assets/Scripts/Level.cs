using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int totalBlocks; // serialized for debugging

    private SceneLoader sceneLoader;

    public void Start()
    {
        totalBlocks = 0;
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void AddCountTotalBlocks()
    {
        totalBlocks++;
    }

    public void DecreaseTotalBlocks()
    {
        totalBlocks--;
        if (totalBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}

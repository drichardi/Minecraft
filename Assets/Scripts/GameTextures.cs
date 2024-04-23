using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTextures : MonoBehaviour
{
    // create static singleton
    public static GameTextures instance;
    [SerializeField]
    public OverlayTextures foliageTextures;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    
}

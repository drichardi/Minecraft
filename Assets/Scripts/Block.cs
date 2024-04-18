using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Block : MonoBehaviour
{
    [SerializeField] string m_DestroyTexAddress;
    [SerializeField] public int hardness = 5;
    [SerializeField] public int fullHealth = 20;
    public int currentHealth;

    public OverlayTextures destruction;

    public string blockName = "stone";
    Renderer renderer;

    MaterialPropertyBlock mpb;

    private AsyncOperationHandle<Texture> m_DestroyTexLoadOpHandle;

    // Start is called before the first frame update
    void Awake()
    {
        renderer = GetComponent<Renderer>();
        mpb = new MaterialPropertyBlock();
        //LoadDestroyTextures();
        
    }

    private void Start()
    {
        currentHealth = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        float healthPercent = (float)currentHealth / fullHealth;

        if (healthPercent > .95)
        {
            mpb.SetTexture("_OverlayDecal", null);
        }
        else if (healthPercent > .9)
        {
            mpb.SetTexture("_OverlayDecal", destruction.textures[0]);
        }
        else if (healthPercent > .8)
        {
            mpb.SetTexture("_OverlayDecal", destruction.textures[1]);
        }
        else if (healthPercent > .7)
        {
            mpb.SetTexture("_OverlayDecal", destruction.textures[2]);
        }
        else if (healthPercent > .6)
        {
            mpb.SetTexture("_OverlayDecal", destruction.textures[3]);
        }
        else if (healthPercent > .5)
        {
            mpb.SetTexture("_OverlayDecal", destruction.textures[4]);
        }
        else if (healthPercent > .4)
        {
            mpb.SetTexture("_OverlayDecal", destruction.textures[5]);
        }
        else if (healthPercent > .3)
        {
            mpb.SetTexture("_OverlayDecal", destruction.textures[6]);
        }
        else if (healthPercent > .2)
        {
            mpb.SetTexture("_OverlayDecal", destruction.textures[7]);
        }
        else if (healthPercent > .1)
        {
            mpb.SetTexture("_OverlayDecal", destruction.textures[8]);
        }
        else if (healthPercent > 0)
        {
            mpb.SetTexture("_OverlayDecal", destruction.textures[9]);
        }
        else
        {
            Destroy(gameObject);
        }
        renderer.SetPropertyBlock(mpb);
    }

    //void LoadDestroyTextures()
    //{
    //    m_DestroyTexLoadOpHandle = Addressables.LoadAssetAsync<Texture>(m_DestroyTexAddress);
    //    m_DestroyTexLoadOpHandle.Completed += OnDestroyTextureLoadComplete;
        
    //}

    //void OnDestroyTextureLoadComplete(AsyncOperationHandle<Texture> asyncOperationHandle)
    //{
    //    Debug.Log($"AsyncOperationHandle Status: {asyncOperationHandle.Status}");
    //    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        //destroyTexture = asyncOperationHandle.Result;
    //    }
    //}
}

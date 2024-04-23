using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;

public class TransparentPlaneTexture : MonoBehaviour
{
    [SerializeField] Foliage foliageType;

    OverlayTextures.FoliageTextures foliage;
    
    Texture selectedTexture;
    MaterialPropertyBlock mpb;
    Renderer renderer;

    [SerializeField] OverlayTextures overlayTextures;

    private void Awake()
    {
        overlayTextures = GameTextures.instance.foliageTextures;
    }
    // Start is called before the first frame update
    void Start()
    {
        foliage = GetFoliage(foliageType);
        renderer = GetComponent<Renderer>();
        selectedTexture = foliage.texture;

        mpb = new MaterialPropertyBlock();
        mpb.SetTexture("_MainTexture", selectedTexture);
        mpb.SetColor("_Color", foliage.color);
        renderer.SetPropertyBlock(mpb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    OverlayTextures.FoliageTextures GetFoliage(Foliage type)
    {
        foreach (var item in overlayTextures.f_textures)
        {
            if (item.foliageType == type)
            {
                return item;
            }
        }
        Debug.LogError("Could not find foliage_type in f_textures SO");
        return null;
    }

    [ContextMenu("UpdateGameObject")]
    public void UpdateGameObject()
    {
        foliage = GetFoliage(foliageType);
        renderer = GetComponent<Renderer>();
        selectedTexture = foliage.texture;

        mpb = new MaterialPropertyBlock();
        mpb.SetTexture("_MainTexture", selectedTexture);
        mpb.SetColor("_Color", foliage.color);
        renderer.SetPropertyBlock(mpb);    
    }

    // Called anytime the script loads or changes in the inspector
    private void OnValidate()
    {
        UpdateGameObject();
    }
}

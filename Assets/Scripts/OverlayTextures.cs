using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Minecraft/Texture Object", order = 2)]
public class OverlayTextures : ScriptableObject
{
    // Textures for overlay / destroy textures
    [SerializeField] public Texture[] textures;

    [Serializable]
    public class FoliageTextures
    {
        public string name;
        public Foliage foliageType;
        public Texture texture;
        public Color color;
    }

    [SerializeField] public FoliageTextures[] f_textures;

   
}

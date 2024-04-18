using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Minecraft/Texture Object", order = 2)]
public class OverlayTextures : ScriptableObject
{
    //[Serializable]
    //public class DestroyedTextures
    //{
    //    public Texture texture;
    //}

    

    [SerializeField] public Texture[] textures;

     
}

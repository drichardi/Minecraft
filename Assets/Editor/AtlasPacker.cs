// https://www.youtube.com/watch?v=l7gO_QL5Jw0&list=PLVsTSlfj0qsWEJ-5eMtXsYp03Y9yF1dEn&index=27
// credit: b3agz

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AtlasPacker : EditorWindow
{
    // Block texture size in pixels
    int blockSize = 16;
    int atlasSizeInBlocks = 32;
    int atlasSize;

    Object[] rawTextures = new Object[1024]; 
    List<Texture2D> sortedTextures = new List<Texture2D>();
    Texture2D atlas;

    [MenuItem ("Minecraft/Atlas Packer")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(AtlasPacker));
    }

    private void OnGUI()
    {
        atlasSize = atlasSizeInBlocks * blockSize;

        GUILayout.Label("Minecraft Texture Atlas Packer", EditorStyles.boldLabel);

        blockSize = EditorGUILayout.IntField("Block Size", blockSize);
        atlasSizeInBlocks = EditorGUILayout.IntField("Atlas Size (in blocks)", atlasSizeInBlocks);

        GUILayout.Label(atlas);

        if (GUILayout.Button("Load Textures"))
        {
            LoadTextures();
            PackAtlas();

            Debug.Log("Atlas Packer: Textures loaded.");
        }

        if (GUILayout.Button("Clear Textures"))
        {
            atlas = new Texture2D(atlasSize, atlasSize);
            Debug.Log("Atlas Packer: Texture cleared.");
        }

        if (GUILayout.Button("Save Atlas"))
        {
            byte[] bytes = atlas.EncodeToPNG();

            try
            {
                File.WriteAllBytes(Application.dataPath + "/Atlas/Packed_Atlas.png", bytes);
            } 
            catch
            {
                // Handle for real in the future
                Debug.Log("Atlas Packer: Couldn't save atlas to file");

            }
        }
    }

    void LoadTextures()
    {
        sortedTextures.Clear();
        rawTextures = Resources.LoadAll("Textures/block", typeof(Texture2D));
      

        int index = 0;
        foreach (Object texture in rawTextures)
        {
            Texture2D tex = (Texture2D)texture;

            if (tex.width == blockSize && tex.height == blockSize)
            {
                sortedTextures.Add(tex);
            } else
            {
                Debug.Log("Asset Packer: " + tex.name + " doesn't match block size. Texture not loaded.");
            }

            index++;
        }

        Debug.Log("Atlas Packer: " + sortedTextures.Count + " loaded.");
    }

    
    void PackAtlas()
    {
        atlas = new Texture2D(atlasSize, atlasSize);

        Color[] pixels = new Color[atlasSize * atlasSize];

        for (int x = 0; x < atlasSize; x++ )
        {
            for (int y = 0; y < atlasSize; y++ ) 
            {
                // Get current block
                int currentBlockXPos = x / blockSize;
                int currentBlockYPos = y / blockSize;
                      
                int index = currentBlockYPos * atlasSizeInBlocks + currentBlockXPos;

                // Get the pixel in current block
                int currentPixelXPos = x - (currentBlockXPos * blockSize);
                int currentPixelYPos = y - (currentBlockYPos * blockSize);

                if (index < sortedTextures.Count)
                {
                    pixels[(atlasSize - y - 1) * atlasSize + x] = sortedTextures[index].GetPixel(currentPixelXPos, blockSize - currentPixelYPos - 1);
                } 
                else
                {
                    pixels[(atlasSize - y - 1) * atlasSize + x] = new Color(0f, 0f, 0f, 0f); // transparent black
                }
            }
        }

        atlas.SetPixels(pixels);
        atlas.Apply();
    }
}

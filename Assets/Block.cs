using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] public int hardness = 5;
    [SerializeField] public int health = 20;
    public Texture[] destroyTextures;


    MeshRenderer[] meshRenderers;
    Material mat;
    Texture texture;
    Material destroyMat;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        Debug.Log(meshRenderers.Length);
        mat = new Material(meshRenderers[1].material);
        texture = mat.mainTexture;
        destroyMat = new Material(mat);

        foreach (var renderer in meshRenderers)
        {
            //renderer.material.EnableKeyword("")
            foreach (var localKeyword in renderer.material.shader.keywordSpace.keywords)
            {
                Debug.Log(localKeyword.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 5)
        {
            destroyMat.mainTexture = destroyTextures[8];
            mat.Lerp(mat, destroyMat, 1f);
            Debug.Log(mat.GetPropertyNames(MaterialPropertyType.Texture));
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                meshRenderers[i].material = mat;
            }
            
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    [SerializeField] GameObject trunkPrefab;
    [SerializeField] GameObject leafPrefab;

    List<GameObject> treeBlocks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GrowTree(new Vector3Int(3, 0, 3));
        GrowTree(new Vector3Int(-2, 0, 5));

        int x, y, z;

        for (int i = 0; i < 5; i++)
        {
            x = Random.Range(-40, 40);
            y = 0;
            z = Random.Range(-40, 40);
            GrowTree(new Vector3Int(x, y, z));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GrowTree(Vector3Int pos)
    {
        Vector3Int growPos = pos;
        GameObject tree = new GameObject("Tree");
        tree.transform.position = growPos;

        int height = Random.Range(5, 15);
        Vector3Int[] branchDirections = {   Vector3Int.forward,
                                            Vector3Int.right,
                                            Vector3Int.back,
                                            Vector3Int.left
                                        };

        for (int i = 0; i < height; i++)
        {
            GameObject trunkblock = Instantiate(trunkPrefab, growPos, Quaternion.identity, tree.transform);
            growPos += Vector3Int.up;
            // keep track of tree blocks?
            treeBlocks.Add(trunkblock);

            // chance for branch growth
            if (Random.Range(0f, 1f) > .6f)
            {
                Vector3Int branchPos = growPos;
                //Debug.Log("Branching!");

                // 0 - forward, 1 - right, 2 - back, 3 - left
                Vector3Int branchDir = branchDirections[Random.Range(0, branchDirections.Length)];
                int branchLength = Random.Range(1, 5);

                while (branchLength > 0)
                {
                    branchPos += branchDir;
                    Instantiate(trunkPrefab, branchPos, Quaternion.identity, tree.transform);
                    branchLength--;
                }
            }
        }
    }
}

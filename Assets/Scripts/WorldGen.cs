using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{

    Dictionary<Vector3Int, string> world = new Dictionary<Vector3Int, string>();

    // Start is called before the first frame update
    void Start()
    {
        Vector3Int origin = new Vector3Int(0, -32, 0);

        for (int xChunks = 0; xChunks < 10; xChunks++)
        {
            for (int zChunks = 0; zChunks < 10; zChunks++)
            {
                int chunkType = Random.Range(0, 5);
                if (chunkType == 0)
                {
                    GeneratePond(origin);
                }
                else if (chunkType == 1)
                {
                    GenerateMountain(origin);
                }
                else if (chunkType == 2)
                {
                    GenerateGarden(origin);
                }
                else if (chunkType == 3)
                {
                    GenerateDungeon(origin);
                }
                else if (chunkType == 4)
                {
                    GenerateVillage(origin);
                }

                origin += new Vector3Int(0, 0, 64);
            }
            origin += new Vector3Int(64, 0, 0);
        }
        

    }

    void GeneratePond(Vector3Int startPos)
    {
        for (int y = startPos.y; y < startPos.y + 64; y++)
        {
            for (int x = startPos.x; x < startPos.x + 64; x++)
            {
                for (int z = startPos.z; z < startPos.z + 64; z++)
                {
                    // Logic
                    //if (world.ContainsKey(new Vector3Int(x + 1, y, z)))
                    world[new Vector3Int(x, y, z)] = "dirt";
                    world[new Vector3Int(x+1, y, z)] = "dirt";
                    world[new Vector3Int(x+2, y, z)] = "dirt";
                    world[new Vector3Int(x+3, y, z)] = "air";
                }
            }
        }


    }

    private void GenerateVillage(Vector3Int origin)
    {
        throw new System.NotImplementedException();
    }

    private void GenerateDungeon(Vector3Int origin)
    {
        throw new System.NotImplementedException();
    }

    private void GenerateGarden(Vector3Int origin)
    {
        throw new System.NotImplementedException();
    }

    private void GenerateMountain(Vector3Int origin)
    {
        throw new System.NotImplementedException();
    }
}

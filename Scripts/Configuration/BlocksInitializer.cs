using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksInitializer : MonoBehaviour
{
    [SerializeField]
    List<GameObject> prefabStandartBlocks;

    void Start()
    {
        int numerOfColums = 11;

        float blockWidth = (ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft) / numerOfColums;
        float blockHeight = 0.66f * blockWidth;

        float row = ScreenUtils.ScreenTop - blockHeight / 2;
        float column = ScreenUtils.ScreenLeft + blockWidth / 2;

        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < numerOfColums; j++)
            {
                Vector2 position = new Vector2(column, row);
                int prefabBlockIndex = 0;
                if(Random.Range(0,10) > 5)
                {
                    prefabBlockIndex = 1 + Random.Range(0, 3);
                }
                GameObject Block = Instantiate(prefabStandartBlocks[prefabBlockIndex], position, Quaternion.identity);
                Block.GetComponent<Block>().SetSize(blockWidth, blockHeight);
                column += blockWidth;
            }
            row -= blockHeight;
            column = ScreenUtils.ScreenLeft + blockWidth / 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

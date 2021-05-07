using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
   private int rows=5;
   private int cols = 8;

   private float tileSize = 1;

    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid(){
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("Background"));
        for(int row=0;row<rows;row++){
            
            for(int col=0;col<cols;col++){
                GameObject tile = (GameObject)Instantiate(referenceTile,transform);

                float posX = col*tileSize;
                float posY = row*-tileSize;

                tile.transform.position = new Vector2(posX,posY);
            }
        }

        Destroy(referenceTile);
        float gridWidth = cols*tileSize;
        float gridHeight = rows*tileSize;

        transform.position = new Vector2(gridWidth/2 + tileSize/2,gridHeight/2-tileSize/2);

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

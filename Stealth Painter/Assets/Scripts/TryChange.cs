using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TryChange : MonoBehaviour
{

    [SerializeField] private TileBase[] tileBase;
    private Tilemap tileMap;

    private float[,] blockTempDataMap = new float[250, 150];

    void Start()
    {
        
    }

    void ChangeCo()
    {
        tileMap = GameObject.Find("Changed Floor").GetComponent("Tilemap") as Tilemap;

        for (int y = 0; y < blockTempDataMap.GetLength(0); y++)
        {
            for (int x = 0; x < blockTempDataMap.GetLength(1); x++)
            {
                tileMap.SetTile(new Vector3Int(y, x, 0), tileBase[0]);
                tileMap.SetColor(new Vector3Int(y, x, 0), Color.red);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //newVect = new Vector2(tf.position.x, tf.position.y);
        Debug.Log("Contact was made!");
        //colourChangeCollision = true;
        //currentDelay = Time.time + colourChangeDelay;
        //tilemap.SetColor(new Vector3Int(y, x, 0), Color.red);
        ChangeCo();
    }

}
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Tilemaps;
using Vector2 = System.Numerics.Vector2;

public class ChangeColor : MonoBehaviour
{
    public float colourChangeDelay = 0.5f;
    float currentDelay = 0f;
    bool colourChangeCollision = false;
    Vector2 newVect;
    private Transform tf;
    private Tilemap tilemap;


    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        checkColourChange();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        newVect = new Vector2(tf.position.x, tf.position.y);
        Debug.Log("Contact was made!");
        colourChangeCollision = true;
        currentDelay = Time.time + colourChangeDelay;
        //tilemap.SetColor(new Vector3Int(y, x, 0), Color.red);
    }

    void checkColourChange()
    {
        if (colourChangeCollision)
        {
            transform.GetComponent<Renderer>().material.color = Color.yellow;
            if (Time.time > currentDelay)
            {
                transform.GetComponent<Renderer>().material.color = Color.white;
                colourChangeCollision = false;
            }
        }
    }
    
    /*
    void TryThis()
    {
        tilemap = GameObject.Find("TermalTileMap").GetComponent("Tilemap") as Tilemap;

        for (int y = 0; y < blockTempDataMap.GetLength(0); y++)
        {
            for (int x = 0; x < blockTempDataMap.GetLength(1); x++)
            {
                tilemap.SetTile(new Vector3Int(y, x, 0), tilemap[0]);
                tilemap.SetColor(new Vector3Int(y, x, 0), Color.red);
            }
        }
    }*/
}

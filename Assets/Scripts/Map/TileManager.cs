using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] GameObject[] tiles;
    [SerializeField] float tileSize;
    private GameObject camera; 

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject firstTile = Instantiate(tiles[0]);
        firstTile.transform.position = new Vector3(0, 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

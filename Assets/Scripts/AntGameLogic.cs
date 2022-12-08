using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AntGameLogic : MonoBehaviour
{
    public Tile empty;
    public Tile dirt;
    public Tile blocker;
    public Grid grid;
    public Tilemap tilemap;
    public AntBehavior ant;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(ant.moveTo(tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition))));
            //tilemap.SetTile(tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)), empty);
        } 

        if (Input.GetMouseButtonDown(1))
        {
            GetTileInformation();
        }
    }

    public void GetTileInformation()
    {
        Tile tile = tilemap.GetTile(tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition))) as Tile;
        Debug.Log(tile.ToString() + ",\nColor: " + tile.color + ",\nFlags: " + tile.flags + ",\nGameObject: " + tile.gameObject + ",\nSprite: " + tile.sprite + ",\nTransform: " + tile.transform);
    }
}

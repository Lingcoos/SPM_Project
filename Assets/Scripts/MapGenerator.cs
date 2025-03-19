using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap tileMap;
    public TileBase tile;
    private Transform player;
    public int renderDistance; //Generator distance

    private Vector3 lastPlayerPos;

    private void Start()
    {
        
        if(FindAnyObjectByType<Player>() != null)  // Avoid error
            player = FindAnyObjectByType<Player>().transform;                    
        GenerateTiles();
        lastPlayerPos = tileMap.WorldToCell(player.position);
    }
    private void Update()
    {
        if(player == null)
            player = FindAnyObjectByType<PlayerNetWrok>().transform;
        Vector3 currentPlayerCell = tileMap.WorldToCell(player.position);
        if (currentPlayerCell != lastPlayerPos) // Check whether player movew
        {

            GenerateTiles();
            DeleteTiles();
            lastPlayerPos = currentPlayerCell;

        }
    }
    private void GenerateTiles() // Generate Tiles
    {
        Vector3Int playerCell = tileMap.WorldToCell(player.position);


        for (int x = playerCell.x - renderDistance; x <= playerCell.x + renderDistance; x++)
        {
            for (int y = playerCell.y - renderDistance; y <= playerCell.y + renderDistance; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, 0);


                if (!tileMap.HasTile(cellPosition))
                {
                    tileMap.SetTile(cellPosition, tile);
                }
            }
        }
    }
    private void DeleteTiles()  //Delete Tiles
    {
        Vector3Int playerCell = tileMap.WorldToCell(player.position);



        foreach (var position in tileMap.cellBounds.allPositionsWithin)
        {
            if (Vector3Int.Distance(position, playerCell) > renderDistance)
            {
                tileMap.SetTile(position, null);
            }
        }
    }


}

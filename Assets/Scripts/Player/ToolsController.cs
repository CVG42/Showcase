using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;

public class ToolsController : MonoBehaviour
{
    CharacterController character;
    Rigidbody2D rb;
    //[SerializeField] float offsetDistance = 1f;
    //[SerializeField] float sizeOfInteractableArea = 1.2f;
    ToolbarController toolbarController;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TilemapReadController tilemapReadController;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] CropsManager cropsManager;
    [SerializeField] TileData plowableTiles;
    private bool isSeeded = false;

    [SerializeField] GameObject hoe;
    [SerializeField] GameObject wateringCan;
    [SerializeField] GameObject seeds;
    private bool canWater;

    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<CharacterController>();
        toolbarController = GetComponent<ToolbarController>();
    }

    private void Start()
    {
        canWater = false;
    }

    void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if(Input.GetMouseButtonDown(0))
        {
            UseToolGrid();
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            hoe.SetActive(true);
            wateringCan.SetActive(false);
            seeds.SetActive(false);
            canWater = false;
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            hoe.SetActive(false);
            wateringCan.SetActive(true);
            seeds.SetActive(false);
            canWater = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            hoe.SetActive(false);
            wateringCan.SetActive(false);
            seeds.SetActive(true);
            canWater = false;
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tilemapReadController.GetGridPosition(Input.mousePosition, true);
    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }

    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
    }
     
    
    /*
    private bool UseToolWorld()
    {
        //Vector2 position = rb.position + character.lastMotionVector * offsetDistance;

        Item item = toolbarController.GetItem;
        if(item == null) { return false; }
        if(item.onAction == null) { return false; }

        bool complete = item.onAction.OnApply(position);
        
        return complete;
    }*/

    private void UseToolGrid()
    {
        if(selectable == true)
        {
            /*
            Item item = toolbarController.GetItem;
            if(item == null) { return; }
            if(item.onTileMapAction == null) { return; }

            bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tilemapReadController);
            */
            
            TileBase tileBase = tilemapReadController.GetTileBase(selectedTilePosition);
            TileData tileData = tilemapReadController.GetTileData(tileBase);

            if(tileData != plowableTiles)
            {
                return;
            }

            if(cropsManager.Check(selectedTilePosition))
            {
                cropsManager.Seed(selectedTilePosition);
                isSeeded = true;
            }
            else
            {
                cropsManager.Plow(selectedTilePosition);
                isSeeded = false;
            }

            if (isSeeded == true && canWater == true)
            {
                cropsManager.WaterSeeded(selectedTilePosition);
            }

            if (isSeeded == false && canWater == true)
            {
                cropsManager.Water(selectedTilePosition);
            }
        }
    }
}

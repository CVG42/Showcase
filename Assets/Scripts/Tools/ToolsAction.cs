using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsAction : ScriptableObject
{
    public virtual bool OnApply(Vector2 worldPoint)
    {
        Debug.LogWarning("OnApply is not implemented");
        return true;
    }

    public virtual bool OnApplyToTileMap(Vector3Int gridPosition, TilemapReadController tilemapReadController)
    {
        Debug.LogWarning("OnApplyToTileMap is not implemented");
        return true;
    }
}

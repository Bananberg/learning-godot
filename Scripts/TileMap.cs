using Godot;
using System;

public partial class TileMap : Node2D
{
    // Grid dimensions
    private int gridWidth = 20;
    private int gridHeight = 20;

    private float tileSpaceFactor = 0.5f;

    public override void _Ready()
    {
        // Calculate total grid width and height including any space between tiles.
        float totalGridWidth = gridWidth * WorldTile.TILE_SIZE * tileSpaceFactor;
        float totalGridHeight = gridHeight * WorldTile.TILE_SIZE * tileSpaceFactor;

        // Calculate the starting position to center the grid at origin (0,0).
        Vector2 startPos = new Vector2(
            -totalGridWidth / 2 + (WorldTile.TILE_SIZE * tileSpaceFactor) / 2,
            -totalGridHeight / 2 + (WorldTile.TILE_SIZE * tileSpaceFactor) / 2
        );


        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                // Create a new tile
                var tile = new WorldTile();

                // Set tile position based on grid coordinates
                int xPos = (int)(startPos.X + (WorldTile.TILE_SIZE * x * tileSpaceFactor));
                int yPos = (int)(startPos.Y + (WorldTile.TILE_SIZE * y * tileSpaceFactor));
                tile.Position = new Vector2(xPos, yPos);

                AddChild(tile);
            }
        }
    }
}

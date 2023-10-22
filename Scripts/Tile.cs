using Godot;
using System;

public partial class WorldTile : Node2D
{
    // Tile size in pixels
    public const int TILE_SIZE = 32;
    const int innerTile = TILE_SIZE - 1;
    const int borderSize = TILE_SIZE - innerTile;

    Color color = Colors.Gray;
    Color borderColor = Colors.Red;
    Rect2 tileRect;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        
        tileRect = new Rect2(Position, new Vector2(innerTile, innerTile));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

    public override void _Draw()
    {
        base._Draw();
        DrawRect(tileRect, color);
        DrawRect(new Rect2(Position, new Vector2(TILE_SIZE, TILE_SIZE)), borderColor, false, borderSize);
    }
}

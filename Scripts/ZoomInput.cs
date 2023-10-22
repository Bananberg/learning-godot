using Godot;
using System;

public partial class ZoomInput : Camera2D
{
    // Zoom speed multiplier
    private float zoomSpeed = 0.1f;

    // Min and Max zoom levels
    private Vector2 minZoom = new Vector2(0.25f, 0.25f);
    private Vector2 maxZoom = new Vector2(4f, 4f);

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton eventMouseButton)
        {
            // Check if the Control key is held down
            if (Input.IsKeyPressed(Key.Ctrl))
            {
                // Check for mouse wheel up
                if (eventMouseButton.ButtonIndex == MouseButton.WheelDown)
                {
                    Zoom -= new Vector2(zoomSpeed, zoomSpeed);
                }
                // Check for mouse wheel down
                else if (eventMouseButton.ButtonIndex == MouseButton.WheelUp)
                {
                    Zoom += new Vector2(zoomSpeed, zoomSpeed);
                }

                // Clamp zoom level to defined min and max
                Zoom = new Vector2(
                    Mathf.Clamp(Zoom.X, minZoom.X, maxZoom.X),
                    Mathf.Clamp(Zoom.Y, minZoom.Y, maxZoom.Y)
                );
            }
        }
    }
}

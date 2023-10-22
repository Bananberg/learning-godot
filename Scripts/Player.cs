using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 50.0f;

	public override void _PhysicsProcess(double delta)
	{

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        
        Vector2 velocity = Velocity;
        if (direction != Vector2.Zero)
		{
			velocity = direction * Speed;
		}
		else
		{
			velocity = Vector2.Zero;
		}

        // Make the character aim towards the mouse pointer
        Vector2 mousePos = GetGlobalMousePosition();
        Rotation = (mousePos - Position).Angle();

        Velocity = velocity;
		MoveAndSlide();
	}

    /*
        the name of the events come from the InputMap that can be found under Project --> Settings --> InputMap in the editor.
    */
    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventKey eventKey)
        {
            GD.Print("InputEvent from key was received: " + eventKey.Keycode);

            if (@event.IsActionPressed("interact"))
            {
                GD.Print("Interacting with world...");
            }
            
            if(eventKey.Keycode == Key.Escape)
            {
                GD.Print("Attempting to close the program...");
                GetTree().Root.PropagateNotification((int)NotificationWMCloseRequest);
            }
        }

        if(@event is InputEventMouseButton eventMouseButton)
        {
            GD.Print("InputEvent from key was received: " + eventMouseButton.ButtonIndex);
            if (@event.IsActionPressed("use_item"))
            {
                GD.Print("Using selected item...");
            }
        }
       

    }
}

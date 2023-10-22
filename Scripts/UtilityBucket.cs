using Godot;
using System;

/*
 * This piece of code is just a bucket of random stuff that doesn't belong on a single Node per se. 
 * I'm just collecting stuff here that later should be managed by the all-encompasing, game-state-handling, uber-parent node. 
 */
public partial class UtilityBucket : Node2D
{
    public override void _Notification(int what)
    {
        if (what == NotificationWMCloseRequest)
            GetTree().Quit(); 
    }
}

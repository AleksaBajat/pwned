using Godot;
using System;

public partial class PlayerCamera : Camera2D
{
	[Export] public Node2D Target { get; set; }
	[Export] public Vector2 Offset2D { get; set; } = Vector2.Zero;
	[Export] public float FollowSpeed { get; set; } = 5.0f;


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Ready()
	{
		if (Target == null)
		{
			Target = GetTree().GetFirstNodeInGroup("Player") as Node2D;
		}

		if (Target != null)
		{
			GlobalPosition = Target.GlobalPosition + Offset2D;
		}
	}

	public override void _PhysicsProcess(double delta){
		if (Target == null)
		{
			return;
		}

		Vector2 desiredPosition = Target.GlobalPosition + Offset2D;
		GlobalPosition = GlobalPosition.Lerp(desiredPosition, FollowSpeed * (float)delta);
	}
}

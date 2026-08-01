using Godot;

public partial class AimComponent : Node2D
{
	[Export] public float Deadzone { get; set; } = 0.25f;
	[Export] public float Smoothing { get; set; } = 20f;

	public Vector2 Direction { get; private set; } = Vector2.Right;

	public override void _Process(double delta)
	{
		if (InputDevice.Instance.UsingGamepad)
		{
			Direction = ReadStick();
			Rotation = Mathf.LerpAngle(Rotation, Direction.Angle(), Smoothing * (float)delta);
		}
		else
		{
			Direction = ReadMouse();
			Rotation = Direction.Angle();
		}
	}

	private Vector2 ReadStick()
	{
		var stick = Input.GetVector("game_aim_left", "game_aim_right", "game_aim_up", "game_aim_down");
		return stick.Length() > Deadzone ? stick.Normalized() : Direction;
	}

	private Vector2 ReadMouse()
	{
		var toMouse = GetGlobalMousePosition() - GlobalPosition;
		return toMouse.LengthSquared() > 1f ? toMouse.Normalized() : Direction;
	}
}

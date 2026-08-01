using Godot;


public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 300.0f;
	[Export] public float DashSpeed = 1500.0f;
	[Export] public float DashCooldown = 0.6f;
	[Export] public float DashDuration = 0.15f;
	[Signal] public delegate void DashedEventHandler(Vector2 direction);

	private float _dashTimeLeft = 0f;
	private float _cooldownLeft = 0f;
	private Vector2 _dashDirection = Vector2.Zero;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		_cooldownLeft = Mathf.Max(0f, _cooldownLeft - (float)delta);
		Vector2 direction = Input.GetVector("game_left", "game_right", "game_up", "game_down");

		if (_dashTimeLeft > 0f)
		{
			_dashTimeLeft -= (float)delta;
			velocity = _dashDirection * DashSpeed;
		}
		else
		{
			if (Input.IsActionJustPressed("game_dash") && _cooldownLeft <= 0f && direction != Vector2.Zero)
			{
				_dashDirection = direction;
				_dashTimeLeft = DashDuration;
				_cooldownLeft = DashCooldown;
				velocity = _dashDirection * DashSpeed;
				EmitSignal(SignalName.Dashed, _dashDirection);
			}
			else
			{
				velocity = direction * Speed;
			}
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}

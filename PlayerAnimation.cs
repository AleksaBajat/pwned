using Godot;

public partial class PlayerAnimation : AnimatedSprite2D
{
	[Export] private AimComponent _aimComponent = null!;

	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		_animatedSprite = this;
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("game_right") || Input.IsActionPressed("game_left") || Input.IsActionPressed("game_up") || Input.IsActionPressed("game_down"))
		{
			if(_aimComponent.Direction.X > 0){
				_animatedSprite.Play("walk_right");
			}else{
				_animatedSprite.Play("walk_left");
			}
		}
		else
		{
			if(_aimComponent.Direction.X > 0){
				_animatedSprite.Play("idle_right");
			}else{
				_animatedSprite.Play("idle_left");
			}
		}
	}

}

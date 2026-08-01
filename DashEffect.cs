using Godot;
using System;

public partial class DashEffect : GpuParticles2D
{
	[Export] private AudioStreamPlayer2D _dashSound;

	public override void _Ready()
	{
		Emitting = false;
		GetParent<Player>().Dashed += OnDashed;
	}

	private void OnDashed(Vector2 direction)
	{
		Rotation = direction.Angle() + Mathf.Pi;
		_dashSound.Play();
		Restart();
	}
}

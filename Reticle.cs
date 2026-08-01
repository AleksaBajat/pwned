using Godot;
using System;

public partial class Reticle : Sprite2D
{
	[Export] public float Distance { get; set; } = 48f;
	[Export] public float Size { get; set; } = 8f;
	[Export] public Color Tint { get; set; } = new(1, 1, 1, 0.8f);

	public override void _Ready()
	{
		Position = new Vector2(Distance, 0f);
	}

	public override void _Draw()
	{
		Vector2[] points =
		{
			new(Size, 0f),
			new(-Size * 0.6f, -Size * 0.6f),
			new(-Size * 0.6f, Size * 0.6f),
		};

		DrawColoredPolygon(points, Tint);
	}
}

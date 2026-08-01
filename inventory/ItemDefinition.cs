using Godot;

[GlobalClass]
public partial class ItemDefinition : Resource
{
	[Export] public string DisplayName { get; set; } = "";
	[Export] public Texture2D Icon { get; set; }
	[Export] public bool Stackable { get; set; }
	[Export] public int MaxStack { get; set; } = 1;
}

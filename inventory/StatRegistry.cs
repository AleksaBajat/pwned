using Godot;

[GlobalClass]
public partial class StatRegistry : Resource
{
	[Export] public StatDefinition Health { get; private set; }
	[Export] public StatDefinition Damage { get; private set; }
}

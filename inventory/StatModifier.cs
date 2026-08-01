using Godot;

public enum ModifierType {
	Flat
}

[GlobalClass]
public partial class StatModifier : Resource {
	[Export] public StatDefinition Stat { get; set; }
	[Export] public ModifierType Type { get; set; }
	[Export] public float Value { get; set; }
}

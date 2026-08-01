using Godot;

[GlobalClass]
public partial class WeaponDefinition : ItemDefinition
{
    [Export] public StatModifier[] Modifiers { get; set; } = [];
}

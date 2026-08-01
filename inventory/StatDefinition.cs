using Godot;

[GlobalClass]
public partial class StatDefinition : Resource
{
    [Export] public string DisplayName { get; set; } = "";
    [Export] public float DefaultValue { get; set; }
    [Export] public bool DisplayAsPercent { get; set; }
}

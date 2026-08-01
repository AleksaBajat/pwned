using Godot;

public partial class GameState : Node
{
    [Export] public StatRegistry Stats { get; private set; }
    public static GameState Instance { get; private set; }

    public Inventory Inventory { get; private set; }
    public int Gold { get; set; }

    public override void _EnterTree()
    {
        Instance = this;
        Inventory = new Inventory(40);
    }
}

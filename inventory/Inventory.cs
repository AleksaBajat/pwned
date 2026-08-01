using Godot;
using Godot.Collections;

public sealed partial class Inventory(int size) : GodotObject
{
	private readonly Array<int>[] _slots = new Array<int>[size];

	public Array<int>[] Slots => _slots;

	// public int Size => _slots.Length;
	// public ItemInstance this[int i] => _slots[i];


}

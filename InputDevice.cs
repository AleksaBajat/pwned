using Godot;
using System;

public partial class InputDevice : Node
{
	public static InputDevice Instance { get; private set; }

	public bool UsingGamepad { get; private set; }
	public bool UsingKeyboardMouse => !UsingGamepad;

	[Export] public float StickDeadzone { get; set; } = 0.25f;
	[Signal] public delegate void DeviceChangedEventHandler(bool usingGamepad);

	public override void _Ready()
	{
		Instance = this;
		ProcessMode = ProcessModeEnum.Always;
	}

	public override void _Input(InputEvent @event)
	{
		bool? gamepad = @event switch
		{
			InputEventJoypadMotion m when Mathf.Abs(m.AxisValue) > StickDeadzone => true,
			InputEventJoypadButton => true,
			InputEventMouseMotion or InputEventMouseButton => false,
			InputEventKey => false,
			_ => null,
		};

		if (gamepad is bool value && value != UsingGamepad)
		{
			UsingGamepad = value;
			EmitSignal(SignalName.DeviceChanged, value);
		}
	}
}

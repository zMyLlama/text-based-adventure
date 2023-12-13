namespace root;

public enum InputEventTypes
{
    MOVEFORWARDS,
    MOVEBACKWARDS,
    MOVERIGHT,
    MOVELEFT,
    BATTLE,
    RERENDER,
}

public class InputEventArgs
{
    public InputEventTypes Type { get; set; }
    public string? Arg { get; set; }
}

/*
 * This class makes it possible to subscribe to the global input system.
 * When someone initializes the class it listens for input on a seperate task making sure not to interfer with the primary code flow
 * When the class is initialized you can add callback functions to the event handler
 */
public class InputListener
{
    private CancellationTokenSource? _cts;
    private Renderer _renderer;
    public event EventHandler<InputEventArgs>? InputEvent;

    private void ListenForInput()
    {
        if (_cts == null)
        {
            _renderer.Log("Input listener was not initialized!", LogTypes.ERROR);
            return;
        }
        while (!_cts.IsCancellationRequested)
        {
            string? readLine = Console.ReadLine()?.ToLower();
            _renderer.ResetCursorToDefault();
            
            if (_cts.IsCancellationRequested) return;
            if (readLine == null) continue;

            string[] actions = readLine.Split(" ");
            
            string primaryAction = actions[0];
            string? actionArg = null;
            if (actions.Length >= 2)
            {
                int getArgsFrom = 1;
                if (InputEventsClass.Dictionary.ContainsKey(actions[0] + actions[1]))
                {
                    primaryAction = actions[0] + actions[1];
                    getArgsFrom = 2;
                }

                if (getArgsFrom >= actions.Length - 1)
                {
                    for (int i = getArgsFrom; i < actions.Length; i++)
                    {
                        actionArg += actions[i];
                        if (i != actions.Length - 1) actionArg += " ";
                    }
                }
            }

            bool existsInEvents = InputEventsClass.Dictionary.ContainsKey(primaryAction);
            if (!existsInEvents) continue;
            InputEventArgs args = new InputEventArgs
            {
                Type = InputEventsClass.Dictionary[primaryAction],
                Arg = actionArg,
            };
            InputEvent?.Invoke(this, args);
        }
    }

    public InputListener(Renderer renderer)
    {
        _renderer = renderer;
    }
    
    /*
     * Initializes the class only if it hasnt been initialized before.
     * Makes a new cancellation token and task, making it possible to terminate the task later.
     */
    public void Initialize()
    {
        if (_cts != null) return;
        _cts = new CancellationTokenSource();
        Task listenForInputTask = new Task(ListenForInput, _cts.Token);
        listenForInputTask.Start();
    }

    /*
     * Terminates the input listening task. Useful for: cutscenes or other times where you want to make sure input is not detected
     */
    public void Terminate()
    {
        _cts?.Cancel();
        _cts = null;
    }
}
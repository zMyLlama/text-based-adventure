namespace root;

public class Player
{
    private Renderer _renderer;
    public int xPosition = 0;
    public int yPosition = 0;

    public Player(Renderer renderer)
    {
        _renderer = renderer;
    }
    
    public void Move(int xOffset = 0, int yOffset = 0, bool dontRender = false)
    {
        xPosition += xOffset;
        yPosition += -yOffset;

        if (dontRender) return;
        _renderer.Render();
    }
}
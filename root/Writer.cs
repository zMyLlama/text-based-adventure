namespace root;

public class Writer
{
    public void WriteToPosition(string message, WritePositions position = WritePositions.LEFT)
    {
        string[] messages = message.Split("\n");
        
        foreach (string messagePiece in messages)
        {
            
            int messageLength = Math.Clamp(messagePiece.Length, 0, Console.WindowWidth);

            switch (position)
            {
                case WritePositions.LEFT:
                    Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                    break;
                case WritePositions.CENTER:
                    Console.SetCursorPosition(Console.WindowWidth / 2 - messageLength / 2, Console.GetCursorPosition().Top);
                    break;
                case WritePositions.RIGHT:
                    Console.SetCursorPosition(Console.WindowWidth - messageLength, Console.GetCursorPosition().Top);
                    break;
            }
            Console.WriteLine(messagePiece);
        }
    }
}
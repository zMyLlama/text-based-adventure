namespace root;

public class Writer
{
    public void WriteToPosition(string message, WritePositions position = WritePositions.LEFT, bool newLine = true)
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
                case WritePositions.MIDLEFT:
                    Console.SetCursorPosition(Console.WindowWidth / 4 - messageLength / 4, Console.GetCursorPosition().Top);
                    break;
                case WritePositions.MIDRIGHT:
                    Console.SetCursorPosition((int)(Console.WindowWidth / (1f + 1f/3f) - messageLength / (1f + 1f/3f)), Console.GetCursorPosition().Top);
                    break;
            }

            if (!newLine)
                Console.Write(messagePiece);
            else
                Console.WriteLine(messagePiece);
        }
    }
}
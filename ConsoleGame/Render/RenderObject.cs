using System;

namespace ConsoleGame.Render
{
    public abstract class RenderObject
    {
        public abstract void Draw(int xOffset, int yOffset);
    }

    public class RenderText : RenderObject
    {
        private readonly string _text;

        public RenderText(string text)
        {
            _text = text;
        }

        public override void Draw(int xOffset, int yOffset)
        {
            var lines = _text.Split('\n');
            for (var i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(xOffset,yOffset+i);
                Console.Write(lines[i]);
            }
        }
    }
}
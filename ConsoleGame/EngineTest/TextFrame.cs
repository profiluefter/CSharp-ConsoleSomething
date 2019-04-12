using System;
using System.Linq;
using System.Runtime.Versioning;
using ConsoleGame.Render;

namespace ConsoleGame
{
    public class TextFrame : Frame
    {
        private string _text;
        private readonly int _xPos;
        private readonly int _yPos;

        private ConsoleColor _color;

        public TextFrame(string text, int xPos, int yPos)
        {
            this._text = text;
            this._xPos = xPos;
            this._yPos = yPos;
            this._color = ConsoleColor.White;
        }

        public override int GetWidth()
        {
            return _text.Split('\n').Select(line => line.Length).Concat(new[] {0}).Max();
        }

        public override int GetHeight()
        {
            return _text.Split('\n').Length;
        }

        public override int GetXOffset()
        {
            return _xPos;
        }

        public override int GetYOffset()
        {
            return _yPos;
        }

        public override void Draw(Action<RenderObject> draw)
        {
            Console.ForegroundColor = _color;
            draw(new RenderText(_text));
        }

        public override void Update()
        {
            var key = Console.ReadKey();
            if (key.KeyChar == _text[0] || (key.KeyChar == '\r' && _text[0] == '\n'))
            {
                _color = ConsoleColor.Green;
                _text = _text.Remove(0, 1);
            }
            else
            {
                _color = ConsoleColor.Red;
            }
        }
    }
}
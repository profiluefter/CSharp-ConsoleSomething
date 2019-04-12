using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleGame.Render
{
    public class RenderConsole
    {
        private readonly int _width;
        private readonly int _height;
        private readonly bool _boarder;

        private readonly List<Frame> _frames;

        public RenderConsole(int width, int height, bool boarder = true)
        {
            this._width = width;
            this._height = height;
            this._frames = new List<Frame>();
            this._boarder = boarder;
            Console.SetWindowSize(width + (boarder ? 2 : 0), height + (boarder ? 2 : 0));
        }

        public void Draw()
        {
            Console.Clear();
            Console.ResetColor();
            if (this._boarder)
                DrawBoarderAround(0, 0, this._width, this._height, 1);

            foreach (var frame in _frames)
            {
                Console.SetCursorPosition(frame.GetXOffset(), frame.GetYOffset());
                frame.Draw(target => { target.Draw(frame.GetXOffset() + (_boarder ? 1 : 0), frame.GetYOffset() + (_boarder ? 1 : 0)); });
                DrawBoarderAround(frame.GetXOffset() + (_boarder ? 1 : 0) - 1, frame.GetYOffset() + (_boarder ? 1 : 0) - 1,
                    frame.GetWidth(), frame.GetHeight(), 1);
            }
            Console.SetCursorPosition(0,_height+(_boarder ? 1 : -1));
        }

        private static void DrawBoarderAround(int offsetX, int offsetY, int width, int height, int size)
        {
            for (var i = 0; i <= width + size; i++)
            {
                try
                {
                    Console.SetCursorPosition(offsetX + i, offsetY);
                    Console.Write("+");
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
            }

            for (var i = 0; i <= width + size; i++)
            {
                try
                {
                    Console.SetCursorPosition(offsetX + i, offsetY + height + size);
                    Console.Write("+");
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
            }

            for (var i = 0; i <= height + size; i++)
            {
                try
                {
                    Console.SetCursorPosition(offsetX, offsetY + i);
                    Console.Write("+");
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
            }

            for (var i = 0; i <= height + size; i++)
            {
                try
                {
                    Console.SetCursorPosition(offsetX + width + size, offsetY + i);
                    Console.Write("+");
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
            }
        }

        public void Add(Frame frame)
        {
            _frames.Add(frame);
        }

        public void Update()
        {
            foreach (var frame in _frames)
            {
                frame.Update();
            }
        }
    }
}
using System;

namespace ConsoleGame.Render
{
    public abstract class Frame
    {
        public abstract int GetWidth();
        public abstract int GetHeight();
        public abstract int GetXOffset();
        public abstract int GetYOffset();
        public abstract void Draw(Action<RenderObject> draw);

        public abstract void Update();
    }
}
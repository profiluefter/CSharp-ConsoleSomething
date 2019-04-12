using System;
using System.Runtime.InteropServices;
using ConsoleGame.Render;

namespace ConsoleGame
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var renderConsole = new RenderConsole(100,25,true);
            renderConsole.Add(new TextFrame("Dies ist ein Text der über mehrere\nZeilen geht, damit ich das testen kann.",0,0));
            renderConsole.Draw();
            while (true)
            {
                renderConsole.Update();
                renderConsole.Draw();
            }
        }
    }
}
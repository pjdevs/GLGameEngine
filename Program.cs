using System;

namespace OpenGLGame
{
    class Program
    {
        static void Main(string[] args)
        { 
            using (Window w = new Window(640, 480, "Hey I'm a title"))
            {
                w.Run();
            }
        }
    }
}

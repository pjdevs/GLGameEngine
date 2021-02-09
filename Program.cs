using OpenGLGame.Graphics;

namespace OpenGLGame
{
    class Program
    {
        static void Main(string[] args)
        { 
            using (Game w = new Game(640, 480, "Hey I'm a title"))
            {
                w.Run();
            }
        }
    }
}

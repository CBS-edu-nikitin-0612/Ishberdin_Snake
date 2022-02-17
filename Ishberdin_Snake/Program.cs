using System.Threading;

namespace Ishberdin_Snake
{
    class Program
    {
        static void Main()
        {
            Game game = new Game();
            Thread thread = new Thread(game.Start);
            thread.Start();
        }
        
    }
}

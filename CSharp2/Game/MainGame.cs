using GameEngineLibraryProject;
using GameProject.Asteroids.GameLevels;
using GameProject.Asteroids.GameObjects;
using System.Drawing;

namespace GameProject
{
    static class MainGame
    {
        public static GameState State { get; set; }

        public static void Init(string playerName)
        {
            State = new GameState
            {
                CurrentScene = new Level1(),
                Player1=new Player(playerName, new Ship(new Point(4,4),Image.FromFile(@"Assets/ship.png")))
            };
            State.CurrentScene.Load();
            (State.Player1.ControlledObject as Ship).Pos = State.CurrentScene.PlayerStartPosition[0];
            State.CurrentScene.Player = State.Player1;
        }

        public static void Start()
        {
            Game.Scene = State.CurrentScene;
            Game.Play();
        }
    }

    public class GameState
    {
        public Player Player1 { get; set; }
        public GameScene CurrentScene { get; set; }
    }
}

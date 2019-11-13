using GameEngineLibraryProject;
using GameEngineLibraryProject.Archetipes;
using System.Drawing;

namespace GameProject.Asteroids.GameObjects
{
    public class Player : IPlayer
    {
        public GameObject ControlledObject { get; set; }
        public string Name { get; set; }
        public int Record { get; private set; } = 0;

        public Player(string name, GameObject gameObject)
        {
            this.ControlledObject = gameObject;
            this.Name = name;

            Program.Log?.Invoke(this, "Created");
        }

        public void DrawPlayerStatusPanel()
        {
            Game.buffer.Graphics.DrawString($"Record: {this.Record}", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Underline), Brushes.White, 200, 10);
            Game.buffer.Graphics.DrawString($"Health: {(this.ControlledObject as IDamagedObject).Health}", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Underline), Brushes.White, 10, 10);
        }

        public void RecordUp(int count)
        {
            Record += count;

            Program.Log?.Invoke(this, $"Record Up on {count} points");
        }
    }
}

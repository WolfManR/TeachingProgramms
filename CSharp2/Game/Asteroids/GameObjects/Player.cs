using GameEngineLibraryProject;
using GameEngineLibraryProject.Archetipes;

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

        public void RecordUp(int count)
        {
            Record += count;

            Program.Log?.Invoke(this, $"Record Up on {count} points");
        }
    }
}

using GameEngineLibraryProject;
using GameEngineLibraryProject.Archetipes;

namespace GameProject.Asteroids.GameObjects
{
    public class Player : IPlayer
    {
        public Player(string name, GameObject gameObject)
        {
            this.ControlledObject = gameObject;
            this.Name = name;
        }
        public GameObject ControlledObject { get; set; }
        public string Name { get; set; }
        public int Record { get; private set; } = 0;
        public void AddRecord(int count)
        {
            Record += count;
        }
    }
}

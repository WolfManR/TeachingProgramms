namespace GameProject.GameEngine
{
    public class Weapon:IGameEngineObject
    {
        public string Name { get; set; }
        public ICollision DamageArea { get; set; }
        public Weapon(ICollision damageArea)
        {
            this.DamageArea = damageArea;
        }

        public void Draw()
        {
            (DamageArea as GameObject).Draw();
        }

        public void Update()
        {
            (DamageArea as GameObject).Update();
        }
    }
}

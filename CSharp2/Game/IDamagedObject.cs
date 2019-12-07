namespace GameProject
{
    public interface IDamagedObject
    {
        bool IsDestroyed { get; }
        int BaseHealth { get; }
        int Health { get; }
        int Damage { get; }
        void Damaged(object obj, int value);
    }
}

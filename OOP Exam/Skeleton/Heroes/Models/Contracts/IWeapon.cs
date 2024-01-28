namespace Heroes.Models.Contracts
{
    public interface IWeapon : IWeaponDmg
    {
        string Name { get; }

        int Durability { get; }

        int DoDamage();
    }
}

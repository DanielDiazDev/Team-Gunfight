using Soldier.Common;

namespace Soldier
{
    public interface IDamageable
    {
        Teams Team { get; }

        void TakeDamage(float amount, string soldierId, Teams team);
    }
}
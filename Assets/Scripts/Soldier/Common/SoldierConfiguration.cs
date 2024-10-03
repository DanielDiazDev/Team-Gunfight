using Inputs;

namespace Soldier.Common
{
    public class SoldierConfiguration
    {
        public readonly IInput Input;
        public readonly float SpeedWalk;
        public readonly float SpeedRun;
        public readonly float Health;
        public readonly bool IsPlayer;
        public readonly int Score;
        public readonly Teams Team;
        public readonly int WeaponIndex;

        public SoldierConfiguration(IInput input, float speedWalk, float speedRun, float health, bool isPlayer, int score, Teams team, int weaponIndex)
        {
            Input = input;
            SpeedWalk = speedWalk;
            SpeedRun = speedRun;
            Health = health;
            IsPlayer = isPlayer;
            Score = score;
            Team = team;
            WeaponIndex = weaponIndex;
        }

    }
}
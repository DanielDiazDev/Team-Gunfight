namespace Soldier.Common
{
    public class SoldierFactory
    {
        private readonly SoldiersConfiguration _configuration;

        public SoldierFactory(SoldiersConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SoldierBuilder Create(string id)
        {
            var prefab = _configuration.GetSoldierById(id);
            return new SoldierBuilder()
                .FromPrefab(prefab);
        }
    }
}
using Soldier.Common;
using UnityEngine;

namespace Soldier
{
    public interface ISoldier
    {
        string Id { get; }
        void OnDamageReceived(bool isDeath, string soldierId, Common.Teams team);
        void SetRotation(Transform target);

        Teams Team { get; }
    }
}
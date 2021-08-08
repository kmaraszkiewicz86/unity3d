using UnityEngine;

namespace Assets.Scripts.Extenstions
{
    public static class EnemyExtension
    {
        public static bool IsGameObjectEnemy(this GameObject gameObject)
        {
            return gameObject.CompareTag("Enemy") || gameObject.IsGamebjectEnemyWithPowerup();
        }

        public static bool IsGamebjectEnemyWithPowerup(this GameObject gameObject)
        {
            return gameObject.CompareTag("EnemyWithPowerup");
        }
    }
}

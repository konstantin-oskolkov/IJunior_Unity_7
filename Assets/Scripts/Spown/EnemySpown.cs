using UnityEngine;


public class EnemySpown : MonoBehaviour
{
   [SerializeField] private EnemyPatrol _enemy;
   [SerializeField] private Transform[] _spawnPoints;

   private void Start()
   {
      foreach (Transform spawnPoint in _spawnPoints)
      {
         EnemyPatrol newEnemy = Instantiate(_enemy, spawnPoint.transform);
         newEnemy.GetPath(spawnPoint.GetComponent<PatrolPath>().WayPoints);
      }
   }
}


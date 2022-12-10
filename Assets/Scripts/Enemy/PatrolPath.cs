using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
   [SerializeField] private Transform _leftPosition;
   [SerializeField] private Transform _rightPosition;

   public List<Transform> WayPoints => new List<Transform> { _leftPosition, _rightPosition };
}

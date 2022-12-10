using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField] private Transform _target;
   [SerializeField] private Vector3 _offset;
   [SerializeField] private float _smothFactor;

   private void LateUpdate()
   {
      Follow();
   }

   private void Follow()
   {
      Vector3 targetPosition = _target.position + _offset;
      Vector3 smothPosition = Vector3.Lerp(transform.position, targetPosition, _smothFactor * Time.deltaTime);
      transform.position = smothPosition;
   }
}

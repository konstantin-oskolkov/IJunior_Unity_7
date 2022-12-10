using UnityEngine;

public class SpownCoin : MonoBehaviour
{
   [SerializeField] private Transform[] _spownPoints;
   [SerializeField] private Coin _coin;

   private void Start()
   {
      CreateCoin();
   }

   private void CreateCoin()
   {
      foreach (var spownPoint in _spownPoints)
         Instantiate(_coin, spownPoint);
   }
}

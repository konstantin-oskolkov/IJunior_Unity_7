using UnityEngine;

public class CoinScore : Score
{
   [SerializeField] private Player _player;

   private void OnEnable()
   {
      _player.ScoreCoinsChanged += OnValueChanged;
   }

   private void OnDisable()
   {
      _player.ScoreCoinsChanged -= OnValueChanged;
   }
}

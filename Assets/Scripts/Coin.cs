using UnityEngine;

public class Coin : MonoBehaviour
{
   [SerializeField] private int _price = 1;

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.TryGetComponent<Player>(out Player player))
      {
         player.AddCoin(_price);
         Destroy(gameObject);
      }
   }
}

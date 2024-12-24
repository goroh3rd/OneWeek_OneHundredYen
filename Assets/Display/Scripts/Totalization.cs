using UnityEngine;

public class Totalization : MonoBehaviour // 自身の上にあるproductsを集計する
{
    [SerializeField] BoxCollider2D boxCollider2D;
    public int Totaling()
    {
        Debug.Log("Totaling");
        Debug.Log("Position: " + transform.position);
        Debug.Log("Size: " + boxCollider2D.bounds.size);
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, new Vector2(boxCollider2D.bounds.size.x, boxCollider2D.bounds.size.y / 2), 0, Vector2.up);
        Debug.Log($"Totaling : { hits.Length - 1}");
        return hits.Length - 1; // 自身の上にあるproductsの数, 1つは自身
    }
}

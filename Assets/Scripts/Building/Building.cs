using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Vector2Int Size = Vector2Int.one;

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                if ((x + y) % 2 == 0) Gizmos.color = new Color(0, 0, 255, 0.3f);
                else Gizmos.color = new Color(255, 0, 0, 0.3f);

                
                Gizmos.DrawCube(transform.position + new Vector3(x, y, 0), new Vector3(1,1f,.1f));
            }
        }
    }
}

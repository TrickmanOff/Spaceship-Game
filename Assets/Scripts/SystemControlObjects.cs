using System.Collections;
using UnityEngine;

public class SystemControlObjects : MonoBehaviour
{
    public Camera _camera;

    private void Start()
    {
        
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}

using UnityEngine;

namespace Prefabs.UI
{
    public class Billboard: MonoBehaviour
    {
        private void Awake()
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}
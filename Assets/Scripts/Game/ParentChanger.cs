using System.Collections.Generic;
using UnityEngine;

namespace Playground.Game
{
    public class ParentChanger : MonoBehaviour
    {
        #region Variables

        private readonly Dictionary<Collider, Transform> _defaultParentsByColliders = new();

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter(Collider other)
        {
            _defaultParentsByColliders.Add(other, other.transform.parent);
            other.transform.SetParent(transform);
        }

        private void OnTriggerExit(Collider other)
        {
            if (_defaultParentsByColliders.Remove(other, out Transform defaultParent))
            {
                other.transform.SetParent(defaultParent);
            }
        }

        #endregion
    }
}
using System;
using UnityEngine;

namespace UI
{
    public class MiniMap : MonoBehaviour
    {
        public Transform Player;

        private void LateUpdate()
        {
            Vector3 newPos = Player.position;
            newPos.y = Player.position.y + 10;
            transform.position = newPos;
        }
    }
}
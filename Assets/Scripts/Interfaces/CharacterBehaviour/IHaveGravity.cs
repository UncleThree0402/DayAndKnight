using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace Interfaces
{
    public interface IHaveGravity
    {
        public Vector3 Gravity(CharacterActor characterActor ,Vector3 velocity);
    }
}
using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace Interfaces
{
    public interface ICanRotate
    {
        public void Rotate(CharacterActor characterActor ,Quaternion quaternion);
    }
}
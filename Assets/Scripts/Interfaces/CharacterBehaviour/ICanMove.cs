using System.Numerics;
using Lightbug.CharacterControllerPro.Core;
using Vector3 = UnityEngine.Vector3;

namespace Interfaces
{
    public interface ICanMove
    {
        public bool CanMove { get; set; }

        public void Move(CharacterActor characterActor ,Vector3 velocity);

        public float UnderSlope(CharacterActor characterActor);

    }
}
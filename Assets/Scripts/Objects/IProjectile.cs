using UnityEngine;

namespace Objects
{
    public interface IProjectile
    {
        void LaunchProjectile(Transform target, float speed);
    }
}

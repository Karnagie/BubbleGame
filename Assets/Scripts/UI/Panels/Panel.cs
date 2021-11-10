using UnityEngine;

namespace Assets.Scripts.UI.Panels
{
    public abstract class Panel : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void ShowOff()
        {
            gameObject.SetActive(false);
        }
    }
}

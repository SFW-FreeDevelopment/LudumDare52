using LD52.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace LD52.UI
{
    [RequireComponent(typeof(Button))]
    public class ExitButton : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("back");
                transform.parent.gameObject.SetActive(false);
            });
        }
    }
}
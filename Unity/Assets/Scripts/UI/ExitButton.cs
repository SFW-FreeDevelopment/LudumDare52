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
            GetComponent<Button>().onClick.AddListener(Close);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Close();
        }

        private void Close()
        {
            var go = transform.parent.gameObject;
            if (!go.activeSelf) return;
            AudioManager.Instance.Play("back");
            go.SetActive(false);
        }
    }
}
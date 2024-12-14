using UnityEngine;

public class Disabler : MonoBehaviour
{
    [SerializeField] private GameObject disabled;

    public void DisableMe()
    {
        disabled.SetActive(false);
    }
}

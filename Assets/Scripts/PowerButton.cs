using UnityEngine;

public class PowerButton : MonoBehaviour
{
    public GameObject TV;

    public void TogglePower()
    {
        TV.SetActive(!TV.activeSelf);
    }
}
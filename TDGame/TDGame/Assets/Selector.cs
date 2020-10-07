using UnityEngine;

public class Selector : MonoBehaviour
{
    public SceneFader sf;

    public void Select(int index)
    {
        sf.FadeTo(index);
    }
}

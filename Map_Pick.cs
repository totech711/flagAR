public class BoundaryManager : MonoBehaviour
{
    public enum MapSize { Small, Medium, Large };
    public MapSize currentMapSize;

    public void SetBoundary(MapSize size)
    {
        switch (size)
        {
            case MapSize.Small:
                SetBoundarySize(10f);
                break;
            case MapSize.Medium:
                SetBoundarySize(20f);
                break;
            case MapSize.Large:
                SetBoundarySize(30f);
                break;
        }
    }

    void SetBoundarySize(float size)
    {
        // Adjust boundary here (e.g., creating colliders or visuals to show boundary limits)
        Debug.Log("Boundary set to: " + size);
    }
}

public class TeamManager : MonoBehaviour
{
    public enum Team { Red, Blue };
    public Team playerTeam;

    public void SetTeam(Team team)
    {
        playerTeam = team;
        // Handle team assignment here (e.g., changing player appearance)
    }
}

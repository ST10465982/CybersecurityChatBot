namespace CyberSecurityAwarenessBotGUI.Models
{
    public class UserMemory
    {
        public string UserName { get; set; } = "";
        public string FavouriteTopic { get; set; } = "";
        public string LastTopic { get; set; } = "";
        public bool HasGreetedUser { get; set; } = false;
    }
}
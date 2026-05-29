using System.IO;
using System.Media;
using System.Windows.Forms;

namespace CyberSecurityAwarenessBotGUI.Services
{
    public class AudioService
    {
        public void PlayGreeting()
        {
            try
            {
                string audioPath = Path.Combine(Application.StartupPath, "Assets", "greeting.wav");

                if (File.Exists(audioPath))
                {
                    SoundPlayer player = new SoundPlayer(audioPath);
                    player.Play();
                }
                else
                {
                    MessageBox.Show(
                        "Voice greeting file was not found. Please make sure greeting.wav is inside the Assets folder.",
                        "Audio File Missing",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch
            {
                MessageBox.Show(
                    "The voice greeting could not be played, but the chatbot will still continue.",
                    "Audio Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
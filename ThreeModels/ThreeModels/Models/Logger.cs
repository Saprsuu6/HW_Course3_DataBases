using System.IO;

namespace ThreeModels.Models
{
    public class Logger
    {
        private string Path { get; set; }

        public Logger()
        {
            Path = "Logs/SelfLogs.txt";
        }

        public void WriteLog(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(Path, true))
                streamWriter.WriteLine(message);
        }
    }
}

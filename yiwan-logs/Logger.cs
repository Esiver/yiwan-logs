using System.Configuration;


namespace yiwan_logs
{
    public class Logger
    {
        private readonly string Path;
        private readonly string FilePath;
        public enum Level { All, Debug, Info, Warning};
        
        

        public Logger() 
        {
            this.Path = ConfigurationManager.AppSettings["logPath"];
            this.FilePath = $"{this.Path}{DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss")}.txt";

            try
            {
                using (StreamWriter writer = File.CreateText(FilePath))
                {
                    writer.WriteLine("This is a new text file created in C#.");
                    writer.WriteLine("You can add more lines of text here.");
                }

                Console.WriteLine($"File '{FilePath}' has been created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }


        public void TryLog(string message, Logger.Level level)
        {
            using (StreamWriter writer = new StreamWriter(this.FilePath, true))
            {
                try
                {
                    writer.WriteLine($"{DateTime.Now} - {level} - {message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR ({DateTime.Now}): {ex})");
                }
            }
        }
        public async void TryLogAsync (string message, Logger.Level level)
        {
            

            using(StreamWriter writer = new StreamWriter(this.FilePath, true))
            {
                
                try
                {
                    await writer.WriteLineAsync($"{DateTime.Now} - {level} - {message}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR ({DateTime.Now}): {ex})");
                }


            }

        }
    }

}

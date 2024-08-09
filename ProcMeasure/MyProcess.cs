using System.Diagnostics;


namespace ProcMeasure
{

    public class ProcModel
    {
        public long MemUsage { get; set; }
        public string ProcName { get; set; }
        public Process Proc { get; set; }
    }
    class MyProcess
    {
        // Opens the Internet Explorer application.
        public void OpenApplication(string myFavoritesPath)
        {
            // Start Internet Explorer. Defaults to the home page.
            Process.Start("IExplore.exe");

            // Display the contents of the favorites folder in the browser.
            Process.Start(myFavoritesPath);
        }

        // Opens urls and .html documents using Internet Explorer.
        public void OpenWithArguments()
        {
            // url's are not considered documents. They can only be opened
            // by passing them as arguments.
            Process.Start("IExplore.exe", "www.northwindtraders.com");

            // Start a Web page using a browser associated with .html and .asp files.
            Process.Start("IExplore.exe", "C:\\myPath\\myFile.htm");
            Process.Start("IExplore.exe", "C:\\myPath\\myFile.asp");
        }

        // Uses the ProcessStartInfo class to start new processes,
        // both in a minimized mode.
        public void OpenWithStartInfo()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;

            Process.Start(startInfo);

            startInfo.Arguments = "www.northwindtraders.com";

            Process.Start(startInfo);
        }
    }
    }

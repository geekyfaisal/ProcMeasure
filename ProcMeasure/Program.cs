// See https://aka.ms/new-console-template for more information
using ProcMeasure;


    var proList = System.Diagnostics.Process.GetProcesses();
    var pmodel = new ProcModel();
    ProcModel[] pArray = new ProcModel[proList.Length];
    int i = 0;

//    string cmdArgs = Environment.GetCommandLineArgs()[1];
    string path = "";
    Console.WriteLine("Enter output path : ");
    path=Console.ReadLine();
//string path = "";
//Console.WriteLine("Enter output path : ");
//path=Console.ReadLine(); 

//File.Create(path);

string createText = "Date,Process,MemoryUsed" + Environment.NewLine;
using (StreamWriter writetext = new StreamWriter(path))
{
    writetext.WriteLine("");
}

foreach (var item in proList)
    {
        long totalBytesOfMemoryUsed = item.WorkingSet64;
        var tmpCls = new ProcModel();
        tmpCls.MemUsage = totalBytesOfMemoryUsed;
        tmpCls.ProcName = item.ProcessName;
        tmpCls.Proc = item;
        pArray[i] = tmpCls;
        createText += DateTime.Now+"," + item.ProcessName + "," + totalBytesOfMemoryUsed + Environment.NewLine;
        i++;
    }

using (StreamWriter writetext = new StreamWriter(path))
{
    writetext.Write(createText);
}


string myFavoritesPath =
                   Environment.GetFolderPath(Environment.SpecialFolder.Favorites);

    MyProcess myProcess = new MyProcess();

    myProcess.OpenApplication(myFavoritesPath);
    myProcess.OpenWithArguments();
    myProcess.OpenWithStartInfo();
    Console.WriteLine("Hello, World!");
Console.ReadLine();

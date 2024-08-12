// See https://aka.ms/new-console-template for more information
using ProcMeasure;


var proList = System.Diagnostics.Process.GetProcesses();
var pmodel = new ProcModel();
ProcModel[] pArray = new ProcModel[proList.Length];
int i = 0;
string path = "";
Console.WriteLine("Enter output path : ");
path = Console.ReadLine();
//string path = "";
//Console.WriteLine("Enter output path : ");
//path=Console.ReadLine(); 

//File.Create(path);

string createText = "Date,Process,MemoryUsed" + Environment.NewLine;

populateData();

if (path != null)
{
    using (StreamWriter writetext = new StreamWriter(path))
    {
        writetext.WriteLine("");
        writetext.Write(createText);
    }
}

string myFavoritesPath =
                   Environment.GetFolderPath(Environment.SpecialFolder.Favorites);

Console.ReadLine();

 void populateData()
{
    var proList = System.Diagnostics.Process.GetProcesses();
    var pmodel = new ProcModel();
    ProcModel[] pArray = new ProcModel[proList.Length];
    int i = 0;
    foreach (var item in proList)
    {
        long totalBytesOfMemoryUsed = item.WorkingSet64;
        var tmpCls = new ProcModel();
        tmpCls.MemUsage = totalBytesOfMemoryUsed;
        tmpCls.ProcName = item.MainWindowTitle;
        tmpCls.Proc = item;
        pArray[i] = tmpCls;
        createText += DateTime.Now + "," + item.ProcessName + "," + totalBytesOfMemoryUsed +","+ item.MainWindowTitle + Environment.NewLine;
        i++;
    }
}
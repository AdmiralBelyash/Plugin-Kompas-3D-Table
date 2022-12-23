using System.Diagnostics;
using Builder;
using KompasApi;
using System;
using System.IO;
using System.Globalization;
using System.Xml.Linq;
using Model;

var builder = new TableBuilder();
var apiService = new KompasWrapper();
var parameters = new TableParameters();
var streamWriter = new StreamWriter($"log.txt", true);

long peakPagedMem = 0,
    peakWorkingSet = 0,
    peakVirtualMem = 0,
    countDetail = 1;
builder.BuildTable(parameters, apiService);

using Process myProcess = Process.GetProcessesByName("kStudy").FirstOrDefault();
do
{
    if (!myProcess.HasExited)
    {
        builder.BuildTable(parameters, apiService);
        countDetail++;
        myProcess.Refresh();
        Console.WriteLine();
        Console.WriteLine($"{myProcess} -");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine($"  Details Count        : {countDetail}");
        Console.WriteLine($"  Physical memory usage     : {myProcess.WorkingSet64}");
        Console.WriteLine($"  User processor time       : {myProcess.UserProcessorTime}");
        streamWriter.WriteLine($"{countDetail} {myProcess.WorkingSet64} {myProcess.UserProcessorTime}");
        streamWriter.Flush();

        Console.WriteLine(myProcess.Responding ? "Status = Running" : "Status = Not Responding");
    }
}
while (countDetail != 200);
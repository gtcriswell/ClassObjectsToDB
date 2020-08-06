using System;
using System.Collections.Generic;

namespace ClassObjectsToDB
{
    class Program
    {
        static void Main(string[] args)
        {

            ConnectionInfo info = new ConnectionInfo("Server=DESKTOP-KBABH9V;Database=TestData;Trusted_Connection=True;");

            SampleData _SampleData = new SampleData();
            _SampleData.TestData = "red";
            _SampleData.Insert();

            _SampleData = new SampleData();
            _SampleData.TestData = "blue";
            _SampleData.Insert();

            _SampleData = new SampleData();
            _SampleData.TestData = "red";
            _SampleData.DateUpdated = DateTime.Now;
            _SampleData.Save();

            _SampleData = new SampleData();
            _SampleData.TestData = "blue";
            _SampleData.Delete();

            _SampleData = SampleData.Load("red");

            List<SampleData> _SampleDataList = SampleData.LoadAll();

        }
    }
}

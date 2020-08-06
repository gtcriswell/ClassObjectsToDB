using System;
using System.Collections.Generic;


namespace ClassObjectsToDB
{

    [SaveProcedure("sp_DataSave")]
    [LoadProcedure("sp_DataLoad")]
    [InsertProcedure("sp_DataInsert")]
    [DeleteProcedure("sp_DataDelete")]
    public class SampleData
    {
        [DeleteAttribute("@TestData", System.Data.SqlDbType.VarChar)]
        [SaveAttribute("@TestData", System.Data.SqlDbType.VarChar)]
        [InsertAttribute("@TestData", System.Data.SqlDbType.VarChar)]
        [LoadAttribute("@TestData", System.Data.SqlDbType.VarChar)]
        [ColMapping("TestData")]
        public string TestData { get; set; }

        [ColMapping("DateAdded")]
        public DateTime DateAdded { get; set; }

        [SaveAttribute("@DateUpdated", System.Data.SqlDbType.DateTime)]
        [ColMapping("DateUpdated")]
        public DateTime DateUpdated { get; set; }

        #region factory

        public static SampleData Load(string TestData)
        {
            SampleData r = new SampleData();
            r.TestData = TestData;
            Factory d = new Factory(DBAction.load);
            List<SampleData> fs = (List<SampleData>)d.DataUtility<SampleData>(r);
            if (fs.Count > 0)
            {
                foreach (var f in fs)
                {
                    if (f.TestData == TestData)
                    {
                        return f;
                    }
                }
            }
            return new SampleData();
        }

        public static List<SampleData> LoadAll()
        {
            Factory d = new Factory(DBAction.load);
            List<SampleData> fs = (List<SampleData>)d.DataUtility<SampleData>(new SampleData());
            if (fs.Count > 0)
            {
                return fs;
            }
            return new List<SampleData>();
        }
        public int Save()
        {

            Factory d = new Factory(DBAction.save);
            return (int)d.DataUtility<SampleData>(this);

        }
        public void Delete()
        {

            Factory d = new Factory(DBAction.delete);
            d.DataUtility<SampleData>(this);

        }
        public void Insert()
        {

            Factory d = new Factory(DBAction.insert);
            d.DataUtility<SampleData>(this);


        }

        public DBAction DataAction { get; set; }

        #endregion


    }
}

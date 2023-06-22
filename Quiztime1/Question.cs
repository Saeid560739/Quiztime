using Quistime1;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quiztime1
{
    class Question
    {
        private long _ID;
        private string _vraag;
        private string _afbeelding;
        private Int32 _tblquizID;



        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string vraag
        {
            get { return _vraag; }
            set { _vraag = value; }
        }

        public string afbeelding
        {
            get { return _afbeelding; }
            set { _afbeelding = value; }
        }


        public Int32 tblquizID
        {
            get { return _tblquizID; }
            set { _tblquizID = value; }
        }





        Sql sql = new Sql();

        public DataSet getData(int quizID)
        {

            string SQL = string.Format("SELECT ID, Vraag, Afbeelding, tblquiz_ID FROM dbquiztime.tblvragen WHERE tblquiz_ID = {0}", quizID);

            return sql.GetDataSet(SQL);
        }

        public DataSet getData_Delete()
        {
            string SQL = "SELECT ID, Vraag, Afbeelding, tblquiz_ID FROM dbquiztime.tblvragen";

            return sql.GetDataSet(SQL);
        }



        //CRUD
        /* public void Create(string vraag, string afbeelding, int tblquiz_ID)


         {
             string SQL = string.Format("INSERT INTO dbquiztime.tblvragen (Vraag, tblquiz_ID) VALUES ('{0}', '{1}')", vraag, tblquiz_ID);
             ID = sql.ExecuteNonQuery(SQL);

             File.Copy(afbeelding, @"../../img/question/" + ID + ".jpg", true);

             SQL = String.Format("UPDATE dbquiztime.tblvragen SET Afbeelding = '../.. /img/question/{0}.jpg' where ID = {0}", ID);
             sql.ExecuteNonQuery(SQL);
         }*/

        public void Create(string vraag, string afbeelding, int tblquiz_ID)


        {

            if (string.IsNullOrEmpty(afbeelding))
            {
                string SQL = string.Format("INSERT INTO dbquiztime.tblvragen (Vraag, tblquiz_ID) VALUES ('{0}', '{1}')", vraag, tblquiz_ID);
                ID = sql.ExecuteNonQuery(SQL);
            }
            else
            {
                string SQL = string.Format("INSERT INTO dbquiztime.tblvragen (Vraag, tblquiz_ID) VALUES ('{0}', '{1}')", vraag, tblquiz_ID);
                ID = sql.ExecuteNonQuery(SQL);

                File.Copy(afbeelding, @"../../img/question/" + ID + ".jpg", true);

                SQL = String.Format("UPDATE dbquiztime.tblvragen SET Afbeelding = '../.. /img/question/{0}.jpg' where ID = {0}", ID);
                sql.ExecuteNonQuery(SQL);
            }
        }


        public void Read(Int32 ID)
        {

            string SQL = string.Format("SELECT ID, Vraag, Afbeelding, tblquiz_ID FROM dbquiztime.tblvragen WHERE ID = {0}", ID);
            DataTable datatable = sql.GetDataTable(SQL);

            _ID = Convert.ToInt32(datatable.Rows[0]["ID"].ToString());
            _vraag = datatable.Rows[0]["Vraag"].ToString();
            _afbeelding = datatable.Rows[0]["Afbeelding"].ToString();
            _tblquizID = Convert.ToInt32(datatable.Rows[0]["tblquiz_ID"].ToString());
        }

        public void showQuestion(Int32 ID)
        {
            string SQL = string.Format("SELECT ID, Vraag, Afbeelding, tblquiz_ID FROM dbquiztime.tblvragen WHERE tblquiz_ID = {0}", ID);
            DataTable datatable = sql.GetDataTable(SQL);

            _ID = Convert.ToInt32(datatable.Rows[0]["ID"].ToString());
            _vraag = datatable.Rows[0]["Vraag"].ToString();
            _afbeelding = datatable.Rows[0]["Afbeelding"].ToString();
            _tblquizID = Convert.ToInt32(datatable.Rows[0]["tblquiz_ID"].ToString());
        }

        public void showQuestion1(long ID, Int32 row)
        {
            string SQL = string.Format("SELECT ID, Vraag, Afbeelding, tblquiz_ID FROM dbquiztime.tblvragen WHERE tblquiz_ID = {0}", ID);
            DataTable datatable = sql.GetDataTable(SQL);

            _ID = Convert.ToInt32(datatable.Rows[row]["ID"].ToString());
            _vraag = datatable.Rows[row]["Vraag"].ToString();
            _afbeelding = datatable.Rows[0]["Afbeelding"].ToString();
            _tblquizID = Convert.ToInt32(datatable.Rows[0]["tblquiz_ID"].ToString());
        }


        public void Update(string id, string afbeelding)
        {

            /*string SQL = String.Format("UPDATE dbquiztime.tblvragen SET Afbeelding = '../.. /img/question/{0}.jpg' where ID = {0}", d;
            sql.ExecuteNonQuery(SQL);*/

            string absolutePath = System.IO.Path.GetFullPath(@"../../img/question/" + id + ".jpg");
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            File.Delete(absolutePath);

            File.Copy(afbeelding, @"../../img/question/" + id + ".jpg", true);

            string SQL = string.Format("Update dbquiztime.tblvragen " +
                                      "Set Afbeelding      = '../.. /img/question/{0}.jpg' " +
                                            "WHERE ID =  {0}", id.ToString());


            sql.ExecuteNonQuery(SQL);
            //System.Windows.MessageBox.Show(id + " is geupdate");

        }

        public void UpdateQuestion(string id, string vraag)
        {

            string SQL = string.Format("Update dbquiztime.tblvragen " +
                                        "Set Vraag     = '{0}' " +
                                        "WHERE ID     = '{1}'", vraag,
                                                           id.ToString());

            sql.ExecuteNonQuery(SQL);
            //System.Windows.MessageBox.Show(id + " is geupdate");

        }

        public bool Delete(Int32 ID)
        {
            bool isDeleted = false;
            if (System.Windows.MessageBox.Show("Moet ik deze gegevens verwijderen?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string SQL = string.Format("DELETE FROM dbquiztime.tblvragen WHERE ID = {0};", ID);
                sql.ExecuteNonQuery(SQL);
                isDeleted = true;

                // System.Windows.MessageBox.Show("gegevens zijn verwijderd");
            }
            return isDeleted;
        }



    }
}

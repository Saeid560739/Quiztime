using Quistime1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quiztime1
{
    class Quiz
    {
        private Int32 _ID;
        private string _naam;
        private string _datum;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string naam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        public string datum
        {
            get { return _datum; }
            set { _datum = value; }
        }



        Sql sql = new Sql();

        public DataSet getData()
        {
            string Sql = "SELECT ID, Naam, Datum FROM dbquiztime.tblquiz";

            return sql.GetDataSet(Sql);
        }



        //CRUD
        public void Create(string naam)
        {
            string Sql = string.Format("INSERT INTO dbquiztime.tblquiz (Naam) VALUES ('{0}')",
                        naam);

            sql.ExecuteNonQuery(Sql);
        }


        public void Read(Int32 ID)
        {
            string Sql = string.Format("SELECT ID, Naam, Datum FROM dbquiztime.tblquiz WHERE ID = {0}", ID);
            DataTable datatable = sql.GetDataTable(Sql);
            _ID = Convert.ToInt32(datatable.Rows[0]["ID"].ToString());
            _naam = datatable.Rows[0]["Naam"].ToString();
            _datum = datatable.Rows[0]["Datum"].ToString();

        }
        public void Update(string ID, string naam)
        {
            string SQL = string.Format("Update dbquiztime.tblquiz " +
                                       "Set Naam     = '{0}' " +
                                       "WHERE ID     = '{1}'", naam,
                                                          ID);

            sql.ExecuteNonQuery(SQL);
            // System.Windows.MessageBox.Show(customerName + " is geupdate");
        }

        public bool Delete(Int32 ID)
        {
            bool isDeleted = false;
            if (System.Windows.MessageBox.Show("Moet ik deze gegevens verwijderen?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string SQL = string.Format("DELETE FROM dbquiztime.tblquiz WHERE ID = {0};", ID);
                sql.ExecuteNonQuery(SQL);
                isDeleted = true;

                // System.Windows.MessageBox.Show("gegevens zijn verwijderd");
            }
            return isDeleted;
        }



    }
}

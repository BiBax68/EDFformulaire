using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Question3
    {
        public Question3()
        {
            InitializeComponent();
        }

        private void BtnOui_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Formulaire;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO dbo.Reponse (libelleReponse) VALUES(@libelleReponse)", sqlCon);
                var id = int.Parse(Id.Text);
                sqlCommand.Parameters.AddWithValue("@libelleReponse", BtnOui.Content);
                //sqlCommand.Parameters.AddWithValue("@question", TxtQuestion.Text);
                //sqlCommand.Parameters.AddWithValue("@idUser", id);

                sqlCommand.ExecuteNonQuery();

                var question4 = new Question4();
                question4.Id.Text = id.ToString();
                question4.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void BtnNon_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Formulaire;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO dbo.Reponse (libelleReponse) VALUES(@libelleReponse)", sqlCon);
                var id = int.Parse(Id.Text);
                sqlCommand.Parameters.AddWithValue("@libelleReponse", BtnNon.Content);

                sqlCommand.ExecuteNonQuery();

                var question4 = new Question4();
                question4.Id.Text = id.ToString();
                question4.Show();
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSansObjet_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Formulaire;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO dbo.Reponse (libelleReponse) VALUES(@libelleReponse)", sqlCon);
                var id = int.Parse(Id.Text);
                sqlCommand.Parameters.AddWithValue("@libelleReponse", btnSansObjet.Content);

                sqlCommand.ExecuteNonQuery();

                var question4 = new Question4();
                question4.Id.Text = id.ToString();
                question4.Show();
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnNecessiteCorrection_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Formulaire;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO dbo.Reponse (libelleReponse) VALUES(@libelleReponse)", sqlCon);
                var id = int.Parse(Id.Text);
                sqlCommand.Parameters.AddWithValue("@libelleReponse", BtnNecessiteCorrection.Content);

                sqlCommand.ExecuteNonQuery();

                var question4 = new Question4();
                question4.Id.Text = id.ToString();
                question4.Show();
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}

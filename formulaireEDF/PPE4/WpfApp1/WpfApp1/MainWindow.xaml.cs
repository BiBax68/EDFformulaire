    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Formulaire;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();            
            try
            {
                /*if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();
                string query = "SELECT COUNT (1) FROM Table_User WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username",txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    questionnaire_un dashboard = new questionnaire_un();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is wrong");
                }*/

                const string query = "SELECT * FROM dbo.Agent WHERE agentName=@Username and password=@Password"; // Les @ protège d'une injection SQL
                var sda = new SqlDataAdapter(query, sqlCon);
                sda.SelectCommand.Parameters.AddWithValue("@Username", txtUsername.Text); //Attribue la valeur du champ Username.text à @Username dans la requête
                sda.SelectCommand.Parameters.AddWithValue("@Password", txtPassword.Password); //Attribue la valeur du champ Password.Password à @Password dans la requête
                var ds=new DataSet();
                sda.Fill(ds,"dbo.Agent");
                if (ds.Tables[0].Rows.Count == 1) // La requete SQL "query" retourne l'unique ligne où le login et mdp correspondent
                {
                    var utilisteurId = ds.Tables[0].Rows[0]["idAgent"].ToString(); // Récupère l'id
                    questionnaire_un dashboard = new questionnaire_un();
                    dashboard.Id.Text = utilisteurId;
                    dashboard.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Login ou mot de passe incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

        }
    }
}

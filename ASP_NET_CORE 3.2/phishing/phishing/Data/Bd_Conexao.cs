using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace phishing.Data
{
    public class Bd_Conexao
    {
        private string caminho = "server=localhost:3306;uid=root;pwd=root;database=phishingProject;";
        private MySqlConnection conexao;

        public MySqlConnection Conexao()
        {
            return this.conexao;
        }

        public Bd_Conexao()
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                //MessageBox.Show("Conectado com sucesso...");
            }
            catch (Exception)
            {
            }
            finally
            {
                conexao.Close();
            }
        }

        public void gravar(int codigo, string nome)
        {
            try
            {
                this.conexao.Open();
                string query = "INSERT INTO famosos (codigo, nome) VALUES (" + codigo + ", '" + nome + "')";

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                //cmd.Parameters.AddWithValue("@codigo", codigo);
                //cmd.Parameters.AddWithValue("@nome", nome);
                cmd.ExecuteNonQuery();

                this.conexao.Close();
               // MessageBox.Show("Dados gravados com sucesso...");
            }
            catch (Exception)
            {
              //  MessageBox.Show("Erro de gravação");
            }
        }

        public void gravarPontuacao(string nome, string email, int pontuacao)
        {
            try
            {
                this.conexao.Open();
                string query = "INSERT INTO phsg_usuario (NOMUSUARIO, DSCEMAIL, NUMPONTUACAO, DATRESPOSTA, IDTSTATUS) VALUES ('" + nome + "', '" + email + "', '" + pontuacao + "', '" + DateTime.Now + "', '" + 'V' + "')";

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                //cmd.Parameters.AddWithValue("@nome", nome);
                //cmd.Parameters.AddWithValue("@sexo", sexo);
                cmd.ExecuteNonQuery();

                this.conexao.Close();
               // MessageBox.Show("Dados gravados com sucesso...");
            }
            catch (Exception erro)
            {
              //  MessageBox.Show("Erro de gravação: Erro -> " + erro);
            }
        }

        public void updateStatusPergunta(int id, string status)
        {

            string query = "UPDATE phsg_pergunta SET (IDTSTATUS)" + 'I' + "WHERE ID" + id;

            try
            {
                this.conexao.Open();
                DataTable dados = new DataTable();

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                dados.Load(cmd.ExecuteReader());

                this.conexao.Close();
            }
            catch (Exception)
            {
                //  MessageBox.Show("Erro ao acessar banco de dados");
            }
        }

        public void updateStatusUsuario(int id, string status)
        {

            string query = "UPDATE phsg_usuario SET (IDTSTATUS)" + 'F' + "WHERE ID" + id;

            try
            {
                this.conexao.Open();
                DataTable dados = new DataTable();

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                dados.Load(cmd.ExecuteReader());

                this.conexao.Close();
            }
            catch (Exception)
            {
              //  MessageBox.Show("Erro ao acessar banco de dados");
           }
        }

        //public void updateTable(DataGridView grid, string tabela)
        //{

        //    string query = "SELECT * FROM " + tabela + ";";
        //    try
        //    {
        //        this.conexao.Open();
        //        DataTable dados = new DataTable();

        //        MySqlCommand cmd = new MySqlCommand(query, this.conexao);
        //        dados.Load(cmd.ExecuteReader());

        //        grid.DataSource = dados.DefaultView;

        //        this.conexao.Close();
        //    }
        //    catch (Exception)
        //    {
        //      //  MessageBox.Show("Erro ao acessar banco de dados");
        //    }
        //}

        public void deleteRegistro(int id)
        {

            string query = "DELETE FROM phsg_usuario WHERE id =" + id;
            try
            {
                this.conexao.Open();

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                cmd.ExecuteNonQuery();
                this.conexao.Close();
            }
            catch (Exception)
            {
               // MessageBox.Show("Erro ao deletar registro...");
            }
        }

    }
}

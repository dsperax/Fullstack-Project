using MySqlConnector;
using phishing.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace phishing.Data
{
    public class Bd_Conexao
    {
        //private string caminho = @"server=NOME DO SERVIDOR.br;uid=USUARIO;pwd=SENHA;database=NOME DO SCHEMA/DB;";
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
            }
            catch (Exception)
            {
            }
            finally
            {
                conexao.Close();
            }
        }

        public void gravarPontuacao(string nome, string email, int pontuacao)
        {
            try
            {
                this.conexao.Open();
                string query = "INSERT INTO phsg_usuario (NOMUSUARIO, DSCEMAIL, NUMPONTUACAO, IDTSTATUS) VALUES ('"+nome+"', '"+email+"', "+pontuacao+", '"+'V'+"')";

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Falha ao gravar pontuação!");
            }
            finally
            {
                this.conexao.Close();
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
            }
            catch (Exception)
            {
                throw new Exception("Falha ao modificar o status da pergunta!");
            }
            finally
            {
                this.conexao.Close();
            }
        }

        public void updateStatusUsuarioParaF(int id, string status)
        {

            string query = "UPDATE phsg_usuario SET (IDTSTATUS)" + 'F' + "WHERE ID" + id;

            try
            {
                this.conexao.Open();
                DataTable dados = new DataTable();

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                dados.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {
                throw new Exception("Falha ao zerar status do usuario");
            }
            finally
            {
                this.conexao.Close();
            }
        }

        public void deleteRegistro(int id)
        {

            string query = "DELETE FROM phsg_usuario WHERE id =" + id;
            try
            {
                this.conexao.Open();

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Falha ao deletar o registro!");
            }
            finally
            {
                this.conexao.Close();
            }
        }

        public Pergunta getPerguntaByNumber(int numPergunta)
        {
            var query = "SELECT * FROM phsg_pergunta WHERE NUMPERGUNTA =" + numPergunta;
            Pergunta pergunta = new Pergunta();
            try
            {
                this.conexao.Open();
                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                cmd.ExecuteNonQuery();
                

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pergunta.Titulo = reader["DSCTITULOPERGUNTA"].ToString();
                    pergunta.Descricao = reader["DSCPERGUNTA"].ToString();
                    pergunta.Resposta = reader["IDTRESPOSTA"].ToString();
                    pergunta.DescricaoResposta = reader["DSCRESPOSTA"].ToString();
                    pergunta.ConteudoDiv = reader["DSCHTMLIMG"].ToString();
                    pergunta.Num_Pergunta = Convert.ToInt32(reader["NUMPERGUNTA"]);
                }
            }
            catch (Exception)
            {
                throw new Exception("Falha ao recuperar a pergunta!");
            }
            finally
            {
                this.conexao.Close();
            }
            return pergunta;
        }

    }
}

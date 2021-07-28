using System.Data.SqlClient;

namespace ptoVenta
{
    class Conexion
    {

        public static SqlConnection conexion()
        {
            string[] lines = System.IO.File.ReadAllLines(@"configsql.ini");
            foreach (string line in lines)
            {
                Form1.eservidor = Form1.eservidor + line;
            }
            Form1.cn = new SqlConnection(Form1.eservidor);
            return Form1.cn;
        }
    }
}

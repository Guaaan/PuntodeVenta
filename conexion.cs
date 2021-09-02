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

        public static SqlConnection conexionloc()
        {
            try
            {
                Form1.locn = new SqlConnection(Form1.cadena);
                Form1.conecto = 1;
                return Form1.locn;
            }
            catch (SqlException)
            {
                Form1.conecto = 0;
                return null;
            }
        }

    }
}

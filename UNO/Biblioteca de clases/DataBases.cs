using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class DataBases
    {
        protected static string stringConnection;
        protected SqlConnection connection;
        protected SqlCommand command;
        protected SqlDataReader reader;

        protected DataBases()
        {
            stringConnection = @"Server=.;Database=UsuariosUNO;Trusted_Connection=True;";
        }
    }
}

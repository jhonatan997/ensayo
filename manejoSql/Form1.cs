using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manejoSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)     
        {
            dgMascotas.DataSource = ConsultarMAscotas();
        }
        public DataTable ConsultarMAscotas()
        {
            SqlConnection ObjCn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=dbMascotas;Data Source=LAPTOP-SS08P4TL");
            SqlCommand ObjCmd = new SqlCommand("uspConsultaMascotas", ObjCn);//se utiliza cuando hay transacciones (insert,delete,update)
            ObjCmd.CommandType = CommandType.StoredProcedure; //commantext que le traigo es un sp
            ObjCn.Open();
            SqlDataReader Dr = ObjCmd.ExecuteReader(); //para ejecutar consultas (comando)
            DataTable dt = new DataTable();
            dt.Load(Dr);
            ObjCn.Close(); //cerrar la base de datos
            return dt;

        }
    }

}

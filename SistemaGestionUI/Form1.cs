using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace SistemaGestionUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ListarUsuarios()
        {
            List<Usuario> usuarios = UsuarioBussiness.GetUsuarios();
            dgvApp.AutoGenerateColumns = true;
            dgvApp.DataSource = usuarios;   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }
    }
}

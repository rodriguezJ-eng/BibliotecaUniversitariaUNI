using System;
using System.Windows.Forms;
using BibliotecaUniversitaria.Forms;

namespace BibliotecaUniversitaria
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Se muestra primero el login. Si el usuario inicia sesión correctamente
            // (DialogResult.OK), se abre el Menú principal.
            using var frmLogin = new frmInicioSesion();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMenu());
            }
        }
    }
}

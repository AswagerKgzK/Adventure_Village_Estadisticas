﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureVillageEstadisticas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        #region Botones

        private void BotonIngresarLogin_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                ControladorLogin Control = new ControladorLogin();
                string Respuesta = Control.IniciarSesion(UsuarioTextBoxLogin.Text, ContraseñaTextBoxLogin.Text);
                if (Respuesta == "Exito")
                {
                    string[] RolUser = Control.RolUser(UsuarioTextBoxLogin.Text);
                    InterfazCarga Entrar = new InterfazCarga();
                    Entrar.Bienvenida(RolUser[0], RolUser[1]);
                    this.Hide();
                }
                else GunaMessageBoxLogin.Show(Respuesta, "Error");
            }
        }

        private void BotonRegistrarse_Click(object sender, EventArgs e)
        {
            Registrarse Abrir = new Registrarse();
            this.Hide();
            Abrir.ShowDialog();
            this.Show();
        }

        private void ControlCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Funciones

        private bool VerificarCampos()
        {
            if (UsuarioTextBoxLogin.Text == "") return false;
            if (ContraseñaTextBoxLogin.Text == "") return false;
            return true;
        }

        #endregion

        #region Eventos adicionales

        private int MoveX, MoveY;

        private void PanelControlLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                MoveX = e.X;
                MoveY = e.Y;
            }
            else
            {
                Left = Left + (e.X - MoveX);
                Top = Top + (e.Y - MoveY);
            }
        }

        #endregion

    }
}

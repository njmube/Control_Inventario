﻿/*
 * Usuario: Ricardo Carrasco
 * Fecha: 30-06-2015
 * Hora: 13:06
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlInsumos.GUI
{
	/// <summary>
	/// Description of Ingresar_Factura.
	/// </summary>
	public partial class formIngresarArticulo : Form
	{
		public formIngresarArticulo()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public void createArticulo()
		{
			//Instancia de la Clase Articulo
			ControlInsumos.DLL.Articulo art = new ControlInsumos.DLL.Articulo();
			//Instancia de la Clase ArticuloDal
			ControlInsumos.DAL.ArticuloDal artDal = new ControlInsumos.DAL.ArticuloDal();
			try 
			{
				if (artTxtArticulo.Text.Length > 0) 
				{
                    if (artDal.countArt() <= 1)
                    {
                        art.IdArticulo = artDal.countArt();
                    }
                    else
                    {
                        art.IdArticulo = artDal.maxArt();
                    }
					
					art.NombreArticulo = artTxtArticulo.Text;
					//Inserción de Articulo a la Base de datos
					int resultado = art.insertArt(art);
					switch (resultado) 
					{
						case  1 :
							MessageBox.Show("Registro Correcto","Mantención Artículo",MessageBoxButtons.OK,MessageBoxIcon.Information);
							limpiar();
							break;
						case 19: 
							MessageBox.Show("Ya existe este artículo","Mantención Artículo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
							break;
					}
				}
			}
			catch (Exception e) 
			{
				MessageBox.Show("Error: "+ e.Message,"Mantención Centros de Costos",MessageBoxButtons.OK,MessageBoxIcon.Information);
						
			}
		}
			//Seteos de la Clase Articulo para su posterior inserción
			
		public void limpiar()
		{
			artTxtArticulo.Clear();
		}
		void ArtBtnCrearClick(object sender, EventArgs e)
		{
			createArticulo();
		}
		
		void ArtBtnSalirClick(object sender, EventArgs e)
		{
			Dispose();
		}
		
		void ArtTxtArticuloKeyDown(object sender, KeyEventArgs e)
		{
			//sirve para ir cambiando de control como el TAB
			if (e.KeyCode == Keys.Enter ) 
			{
				this.SelectNextControl(artTxtArticulo,true,true,false,false);
			}		
		}
	}
}

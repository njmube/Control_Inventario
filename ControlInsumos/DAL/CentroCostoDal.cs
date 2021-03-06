﻿/*
 * Usuario: Ricardo Carrasco
 * Fecha: 30-06-2015
 * Hora: 13:06
 */
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ControlInsumos.DAL
{
	/// <summary>
	/// Description of CentroCostoDal.
	/// </summary>
	public class CentroCostoDal
	{
		BaseDeDatosLite b = new BaseDeDatosLite();
		Conn conn = new Conn();
		public int insertCC(DLL.CentroCosto cc)
		{
			
				string sql = "INSERT INTO centroCosto VALUES(" + cc.IdCC + ",'" + cc.Nombre + "'," + cc.IdEmpresa + ");";
				return b.executecommand(sql);	
		}
				
				
			
		public List<DLL.CentroCosto> listCentroCosto()
		{
			try 
			{
			List<DLL.CentroCosto> listaCC = new List<ControlInsumos.DLL.CentroCosto>();
			SQLiteCommand sql = new SQLiteCommand("SELECT * FROM centroCosto", conn.connection());
			SQLiteDataReader reader = sql.ExecuteReader();
               while (reader.Read())
               {
                   DLL.CentroCosto cc = new DLL.CentroCosto();
                   cc.IdCC = reader.GetInt32(0);
                   cc.Nombre = reader.GetString(1);
                   listaCC.Add(cc);
               }
			return listaCC;
			} 
			catch (Exception)
			{
			 return null;	
			}
		}
        public int modificarCC(DLL.CentroCosto c, int idLocalOriginal)
        {
            string sql = "UPDATE centroCosto SET idLocal = '" + c.IdCC + "', nombreCentroCosto = '" + c.Nombre + "', idEmpresa = " + c.IdEmpresa + "  WHERE Idlocal = " + idLocalOriginal + ";";
            return b.executecommand(sql);
        }
        public int eliminarCC(int idLocal)
        {
            string sql = "DELETE FROM centroCosto WHERE Idlocal = " + idLocal + ";";
            return b.executecommand(sql);
        }
        public int eliminarCCXEmpresa(int idEmpresa)
        {
            string sql = "DELETE FROM centroCosto WHERE idEmpresa = " + idEmpresa + ";";
            return b.executecommand(sql);
        }
	}
}

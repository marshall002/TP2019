using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTR
{
	public class Log
	{
		public static void WriteLog(string strMessage)
		{
			string strPath = @"C:\\TP2019\Log.txt";
			string strDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture); // 12 horas

			PrepareLog(strPath);

			using (StreamWriter sw = new StreamWriter(strPath, true, Encoding.Unicode))
			{
				sw.WriteLine(strDate + " >> " + strMessage);
			}

		}

		private static void PrepareLog(string strPath)
		{
			if (!File.Exists(strPath))
			{
				using (File.CreateText(strPath))
				{
				}
			}
		}


	}
}


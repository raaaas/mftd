/*
 * Created by SharpDevelop.
 * User: User
 * Date: Thu 16.02.17
 * Time: 1:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace created.date
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			string[] filePaths = Directory.GetFiles(@"H:\\FOUND.000\\ChkBack 2 Results\\","*",SearchOption.AllDirectories);
			foreach(string name  in  filePaths){
				
				var created = File.GetLastWriteTime(name);
				try {
					string newPath = Path.Combine(Path.GetDirectoryName(name) + "\\", created.Year.ToString(), created.Month.ToString());
					bool exists = Directory.Exists(newPath);
					if (!exists)
						Directory.CreateDirectory(newPath);
					newPath = newPath + "\\" + Path.GetFileName(name);
					File.Move(@name, newPath);				
					textBox2.AppendText(created.ToString() + Environment.NewLine);
				} catch {
					textBox2.AppendText("The process failed:");
				}
			}
		}
	}
}

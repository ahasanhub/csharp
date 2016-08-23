using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace SqlScriptDeployment
{
    class Program
    {
        public static string LogMessage { get; set; }
        static void Main(string[] args)
        {
            LogMessage = string.Empty;
            string sqlConnectionString = @"server=SHOBUZ-PC\SQLEXPRESS;initial catalog=cmd_ehr;UID=sa;PWD=mzaman9";
            string script = File.ReadAllText(@"C:\EHRDBScript\script1.sql");
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            Server server = new Server(new ServerConnection(conn));
            server.ConnectionContext.InfoMessage += new SqlInfoMessageEventHandler(myConnection_InfoMessage);

            server.ConnectionContext.BeginTransaction();

            server.ConnectionContext.ExecuteNonQuery(script);
            server.ConnectionContext.CommitTransaction();

            server.ConnectionContext.InfoMessage -= new SqlInfoMessageEventHandler(myConnection_InfoMessage);
            WriteLog(LogMessage, "Test");

        }
        private static void myConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            LogMessage += e.Message + Environment.NewLine;

        }

        private static void WriteLog(string logMessage, string clientId)
        {
            // Create a writer and open the file:
            StreamWriter log;

            log = !File.Exists("logfile.txt") ? new StreamWriter("logfile.txt") : File.AppendText("logfile.txt");

            // Write to the file:
            log.WriteLine(clientId + "(" + DateTime.Now + ")");
            log.WriteLine("-------------------------------------------");
            log.WriteLine(logMessage);
            log.WriteLine();

            // Close the stream:
            log.Close();
        }
    }
}

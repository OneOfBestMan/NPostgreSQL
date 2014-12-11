/*  This file is part of NPostgreSQL Utilities.

    This is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with PostreSQL Utilities.  If not, see <http://www.gnu.org/licenses/>.
  
    Author : Riaan van der Westhuizen (riaanvdw@outlook.com)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostgreSQL
{
    /// <summary>
    /// PostgreSQL pg_restore utility
    /// http://www.postgresql.org/docs/9.3/static/app-pgrestore.html
    /// </summary>
    public class RestoreInfo : Utilty
    {
        #region Members
        private string input = String.Empty;        
        private bool exitOnError = false;
        private List<string> onlySchemas = new List<string>();
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructors
        /// </summary>
        public RestoreInfo() : base() 
        {
            UtilityFile = "pg_restore.exe";
        }

        /// <summary>
        /// Constructors with Connection Info.
        /// </summary>
        /// <param name="host">Specifies the host name of the machine on which the server is running.</param>
        /// <param name="port">Specifies the TCP port or local Unix domain socket file extension on which the server is listening for connections.</param>
        /// <param name="database">Specifies the name of the database to connect to.</param>
        /// <param name="username">User name to connect as.</param>
        /// <param name="password">User password.</param>
        public RestoreInfo(string host, int port, string database, string username, string password) : base(host, port, database, username, password) 
        {
            UtilityFile = "pg_restore.exe";
        }
        #endregion

        #region Options
        /// <summary>
        /// Specifies the location of the archive file (or directory, for a directory-format archive) to be restored. If not specified, the standard input is used.
        /// filename
        /// </summary>
        public string Input
        {
            get { return input; }
            set { input = value; }
        }
               
        /// <summary>
        /// Exit if an error is encountered while sending SQL commands to the database. The default is to continue and to display a count of errors at the end of the restoration.
        /// -e
        /// --exit-on-error
        /// </summary>
        public bool ExitOnError
        {
            get { return exitOnError; }
            set { exitOnError = value; }
        }

        /// <summary>
        /// Restore only objects that are in the named schema. This can be combined with the -t option to restore just a specific table.
        /// -n namespace
        /// --schema=schema
        /// </summary>
        public List<string> OnlySchemas
        {
            get { return onlySchemas; }
            set { onlySchemas = value; }
        }
        #endregion

        #region Arguments
        public override string Arguments()
        {
            StringBuilder arguments = new StringBuilder();

            arguments.Append(" " + input);

            if (exitOnError)
                arguments.Append(" -e");
            
            return arguments.ToString();
        }
        #endregion

    }
}

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
using System.Threading.Tasks;

namespace API
{
    internal class PgCtrl : UtilityBase
    {
        #region Constructors
        public PgCtrl(string ExecutablePath)
        {
            this.ExecutablePath = ExecutablePath;
            this.ExecutableFilename = "pg_ctrl.exe";
        }
        #endregion

        #region Public
        /// <summary>
        /// Creates a new PostgreSQL database cluster.
        /// </summary>
        /// <param name="dataDirectory">Specifies the file system location of the database configuration files.</param>
        /// <param name="options">Specifies options to be passed directly to the initdb command.</param>
        /// <remarks>
        /// A database cluster is a collection of databases that are managed by a single server instance.
        /// This mode invokes the initdb command. 
        /// </remarks>
        public void Initialize(string dataDirectory, InitDbOptions options = null)
        {
            StringBuilder arguments = new StringBuilder();

            arguments.Append(" init");
            arguments.Append(String.Format(" -D {0}", dataDirectory));
            if (options != null)
                arguments.Append(String.Format(" -o '{0}'", options.Arguments));

            Execute(arguments.ToString());
        }

        // Start
        public void Start()
        {
            StringBuilder arguments = new StringBuilder();
            arguments.Append(" start");


            Execute(arguments.ToString());
        }

        // Stop
        public void Stop()
        {
            StringBuilder arguments = new StringBuilder();

            Execute(arguments.ToString());
        }

        // Restart
        public void Restart()
        {
            StringBuilder arguments = new StringBuilder();

            Execute(arguments.ToString());
        }

        // Reload
        public void Reload()
        {
            StringBuilder arguments = new StringBuilder();

            Execute(arguments.ToString());
        }

        // Status
        public void Status()
        {
            StringBuilder arguments = new StringBuilder();

            Execute(arguments.ToString());
        }

        // Kill
        public void Kill()
        {
            StringBuilder arguments = new StringBuilder();

            Execute(arguments.ToString());
        }

        // Register
        public void Register()
        {
            StringBuilder arguments = new StringBuilder();

            Execute(arguments.ToString());
        }

        // UnRegister
        public void UnRegister()
        {
            StringBuilder arguments = new StringBuilder();

            Execute(arguments.ToString());
        }

        #endregion

        #region Private
        
        #endregion
    }
}

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

        #region Initialize
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
        #endregion

        #region Start
        /// <summary>
        /// Start Server instance.
        /// </summary>
        /// <param name="dataDirectory">Specifies the file system location of the database configuration files.</param>
        /// <param name="filename">Append the server log output to filename.</param>
        public void Start(string dataDirectory, string filename = null)
        {
            StringBuilder arguments = new StringBuilder();

            arguments.Append(" start");
            arguments.Append(String.Format(" -D {0}", dataDirectory));
            if (filename != null)
                arguments.Append(String.Format(" -l '{0}'", filename));

            Execute(arguments.ToString());
        }
        #endregion

        #region Stop
        /// <summary>
        /// Stop the server that is running in the specified data directory is shut down.
        /// </summary>
        /// <param name="dataDirectory">Specifies the file system location of the database configuration files.</param>
        /// <param name="shutdownMode">Specifies the shutdown mode.</param>
        public void Stop(string dataDirectory, PgCtrlShutdownMode shutdownMode = PgCtrlShutdownMode.Smart)
        {
            StringBuilder arguments = new StringBuilder();

            arguments.Append(" stop");
            arguments.Append(String.Format(" -D {0}", dataDirectory));

            switch(shutdownMode)
            {
                case PgCtrlShutdownMode.Fast:
                    arguments.Append(" -m f");
                    break;
                case PgCtrlShutdownMode.Immediate:
                    arguments.Append(" -m i");
                    break;
                case PgCtrlShutdownMode.Smart:
                    arguments.Append(" -m s");
                    break;
            }

            Execute(arguments.ToString());
        }
        #endregion

        #region Restart
        /// <summary>
        /// Restart mode effectively executes a stop followed by a start.
        /// </summary>
        /// <param name="dataDirectory">Specifies the file system location of the database configuration files.</param>
        /// <param name="shutdownMode">Specifies the shutdown mode.</param>
        public void Restart(string dataDirectory, PgCtrlShutdownMode shutdownMode = PgCtrlShutdownMode.Smart)
        {
            StringBuilder arguments = new StringBuilder();

            arguments.Append(" restart");
            arguments.Append(String.Format(" -D {0}", dataDirectory));

            switch (shutdownMode)
            {
                case PgCtrlShutdownMode.Fast:
                    arguments.Append(" -m f");
                    break;
                case PgCtrlShutdownMode.Immediate:
                    arguments.Append(" -m i");
                    break;
                case PgCtrlShutdownMode.Smart:
                    arguments.Append(" -m s");
                    break;
            }

            Execute(arguments.ToString());
        }
        #endregion

        #region Reload
        /// <summary>
        /// reload mode simply sends the postgres process a SIGHUP signal, causing it to reread its configuration files (postgresql.conf, pg_hba.conf, etc.).
        /// </summary>
        /// <param name="dataDirectory">Specifies the file system location of the database configuration files.</param>
        public void Reload(string dataDirectory)
        {
            StringBuilder arguments = new StringBuilder();

            arguments.Append(" reload");
            arguments.Append(String.Format(" -D {0}", dataDirectory));

            Execute(arguments.ToString());
        }
        #endregion

        #region Status
        /// <summary>
        /// Status mode checks whether a server is running in the specified data directory.
        /// </summary>
        /// <param name="dataDirectory">Specifies the file system location of the database configuration files.</param>
        public void Status(string dataDirectory)
        {
            StringBuilder arguments = new StringBuilder();

            arguments.Append(" status");
            arguments.Append(String.Format(" -D {0}", dataDirectory));

            Execute(arguments.ToString());
        }
        #endregion

        #region Promote
        /// <summary>
        /// In promote mode, the standby server that is running in the specified data directory is commanded to exit recovery and begin read-write operations.
        /// </summary>
        /// <param name="dataDirectory">Specifies the file system location of the database configuration files.</param>
        public void Promote(string dataDirectory)
        {
            StringBuilder arguments = new StringBuilder();

            arguments.Append(" promote");
            arguments.Append(String.Format(" -D {0}", dataDirectory));

            Execute(arguments.ToString());
        }
        #endregion

        #region Kill
        /// <summary>
        /// Kill mode allows you to send a signal to a specified process.
        /// </summary>
        /// <param name="processId">Signal name process id</param>
        public void Kill(int processId)
        {
            StringBuilder arguments = new StringBuilder();

            arguments.Append(" kill");
            arguments.Append(String.Format(" {0}", processId));

            Execute(arguments.ToString());
        }
        #endregion

        #region Register
        /// <summary>
        /// register mode allows you to register a system service on Microsoft Windows.
        /// </summary>
        /// <param name="serviceName">Name of the system service to register.</param>
        /// <param name="userName">User name for the user to start the service.</param>
        /// <param name="password">Password for the user to start the service.</param>
        /// <param name="dataDirectory">Specifies the file system location of the database configuration files.</param>
        /// <param name="startType">Start type of the system service to register.</param>
        public void Register(string serviceName, string userName, string password, string dataDirectory, PgCtrlStartType startType = PgCtrlStartType.Auto)
        {
            StringBuilder arguments = new StringBuilder();

            arguments.Append(" register");
            arguments.Append(String.Format(" -N {0}", serviceName));
            arguments.Append(String.Format(" -U {0}", userName));
            arguments.Append(String.Format(" -P {0}", password));
            arguments.Append(String.Format(" -D {0}", dataDirectory));

            switch(startType)
            {
                case PgCtrlStartType.Auto:
                    arguments.Append(" -S a");
                    break;
                case PgCtrlStartType.Demand:
                    arguments.Append(" -S d");
                    break;
            }

            Execute(arguments.ToString());
        }
        #endregion

        #region UnRegister
        /// <summary>
        /// unregister mode allows you to unregister a system service on Microsoft Windows.
        /// </summary>
        /// <param name="serviceName">Name of the system service to unregister.</param>
        public void UnRegister(string serviceName)
        {
            StringBuilder arguments = new StringBuilder();

            arguments.Append(" unregister");
            arguments.Append(String.Format(" -N {0}", serviceName));

            Execute(arguments.ToString());
        }
        #endregion

        #endregion

    }
}

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
    /// PostgreSQL pg_dump Utility
    /// http://www.postgresql.org/docs/9.3/static/app-pgdump.html
    /// </summary>
    public class BackupInfo 
    {
        #region Members
        private bool oids = false;
        private bool blobs = true;
        private int compress = 5;
        private string encoding = "UTF8";
        private string output = String.Empty;        
        private FileFormat outputFormat = FileFormat.Custom;
        
        private List<string> onlySchemas = new List<string>();
        private List<string> excludeSchemas = new List<string>();
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructors
        /// </summary>
        public BackupInfo() : base() 
        {
            //UtilityFile = "pg_dump.exe";
        }

        /// <summary>
        /// Constructors with Connection Info.
        /// </summary>
        /// <param name="host">Specifies the host name of the machine on which the server is running.</param>
        /// <param name="port">Specifies the TCP port or local Unix domain socket file extension on which the server is listening for connections.</param>
        /// <param name="database">Specifies the name of the database to connect to.</param>
        /// <param name="username">User name to connect as.</param>
        /// <param name="password">User password.</param>
        public BackupInfo(string host, int port, string database, string username, string password) 
        {
            //UtilityFile = "pg_dump.exe";
        }
        #endregion

        #region Options
        /// <summary>
        /// Include large objects in the dump. 
        /// This is the default behavior except when --schema, --table, or --schema-only is specified, so the -b switch is only useful to add large objects to selective dumps.
        /// -b
        /// --blobs
        /// </summary>
        public bool Blobs
        {
            get { return blobs; }
            set { blobs = value; }
        }

        /// <summary>
        /// Send output to the specified file. 
        /// This parameter can be omitted for file based output formats, in which case the standard output is used. 
        /// It must be given for the directory output format however, where it specifies the target directory instead of a file. 
        /// In this case the directory is created by pg_dump and must not exist before.
        /// -f file
        /// --file=file
        /// </summary>
        public string Output
        {
            get { return output; }
            set { output = value; }
        }

        /// <summary>
        /// Selects the format of the output.
        /// -F format
        /// --format=format
        /// </summary>
        public FileFormat OutputFormat
        {
            get { return outputFormat; }
            set 
            { 
                outputFormat = value; 
                switch(outputFormat)
                {
                    case FileFormat.Plain:
                        compress = 0;
                        break;
                    case FileFormat.Custom:
                        compress = 5;
                        break;
                }
            }
        }

        /// <summary>
        /// Dump only schemas matching schema; this selects both the schema itself, and all its contained objects. 
        /// When this option is not specified, all non-system schemas in the target database will be dumped.
        /// -n schema
        /// --schema=schema
        /// </summary>
        public List<string> OnlySchemas
        {
            get { return onlySchemas; }
            //set { onlySchemas = value; }
        }

        /// <summary>
        /// Do not dump any schemas matching the schema pattern. 
        /// The pattern is interpreted according to the same rules as for -n. -N can be given more than once to exclude schemas matching any of several patterns.
        /// -N schema
        /// --exclude-schema=schema
        /// </summary>
        public List<string> ExcludeSchemas
        {
            get { return excludeSchemas; }
            //set { excludeSchemas = value; }
        }

        /// <summary>
        /// Dump object identifiers (OIDs) as part of the data for every table. Use this option if your application references the OID columns in some way (e.g., in a foreign key constraint). 
        /// Otherwise, this option should not be used.
        /// -o
        /// --oids
        /// </summary>
        public bool OIDS
        {
            get { return oids; }
            set { oids = value; }
        }
                
        /// <summary>
        /// Create the dump in the specified character set encoding. By default, the dump is created in the database encoding. 
        /// (Another way to get the same result is to set the PGCLIENTENCODING environment variable to the desired dump encoding.)
        /// -E encoding
        /// --encoding=encoding
        /// </summary>
        public string Encoding
        {
            get { return encoding; }
            set { encoding = value; }
        }

        /// <summary>
        /// Specify the compression level to use. Zero means no compression. 
        /// For the custom archive format, this specifies compression of individual table-data segments, and the default is to compress at a moderate level. 
        /// For plain text output, setting a nonzero compression level causes the entire output file to be compressed, as though it had been fed through gzip; but the default is not to compress. 
        /// The tar archive format currently does not support compression at all.
        /// -Z 0..9
        /// --compress=0..9
        /// </summary>
        public int Compress
        {
            get { return compress; }
            set { compress = value; }
        }
        #endregion

        #region Arguments
        /// <summary>
        /// pg_dump command-line arguments
        /// </summary>
        /// <returns></returns>
        public string Arguments()
        {
            StringBuilder arguments = new StringBuilder();
            
            if (blobs)
                arguments.Append(" -b");
            
            arguments.Append(" -E " + encoding);

            arguments.Append(" -f \"" + output + "\"");
            arguments.Append(FormatArguments());

            arguments.Append(OnlyExcludeAgruments(onlySchemas, "-n"));
            arguments.Append(OnlyExcludeAgruments(excludeSchemas, "-N"));
            
            if (oids)
                arguments.Append(" -o ");

            return arguments.ToString();
        }
        #endregion

        #region Private
        private string FormatArguments()
        {
            string formatType = String.Empty;
            bool needCompress = false;
            string arguments = "";

            switch(outputFormat)
            {
                case FileFormat.Plain:
                    formatType = "p";
                    needCompress = true;
                    break;
                case FileFormat.Custom:
                    formatType = "c";
                    needCompress = true;
                    break;
                case FileFormat.Directory:
                    formatType = "d";
                    break;
                case FileFormat.Tar:
                    formatType = "t";
                    break;
            }
            arguments += (" -F " + formatType);

            if (needCompress)
                arguments += (" -Z " + compress.ToString());

            return arguments;
        }

        private string OnlyExcludeAgruments(List<string> list, string option)
        {
            StringBuilder arguments = new StringBuilder();

            foreach (string value in list)
                arguments.Append(" " + option + " " + value);

            return arguments.ToString();
        }
        #endregion
    }
}

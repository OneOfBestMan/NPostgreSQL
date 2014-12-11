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
    /// Specify format of the archive.
    /// </summary>
    public enum FileFormat
    {
        /// <summary>
        /// Output a plain-text SQL script file (the default).
        /// </summary>
        Plain,
        /// <summary>
        /// Output a custom-format archive suitable for input into pg_restore. 
        /// Together with the directory output format, this is the most flexible output format in that it allows manual selection and reordering of archived items during restore. 
        /// This format is also compressed by default.
        /// </summary>
        Custom,
        /// <summary>
        /// Output a directory-format archive suitable for input into pg_restore. 
        /// This will create a directory with one file for each table and blob being dumped, plus a so-called Table of Contents file describing the dumped objects in a machine-readable format that pg_restore can read. 
        /// A directory format archive can be manipulated with standard Unix tools; for example, files in an uncompressed archive can be compressed with the gzip tool. 
        /// This format is compressed by default and also supports parallel dumps.
        /// </summary>
        Directory,
        /// <summary>
        /// Output a tar-format archive suitable for input into pg_restore. 
        /// The tar-format is compatible with the directory-format; 
        /// extracting a tar-format archive produces a valid directory-format archive. 
        /// However, the tar-format does not support compression and has a limit of 8 GB on the size of individual tables. 
        /// Also, the relative order of table data items cannot be changed during restore.
        /// </summary>
        Tar
    }
}

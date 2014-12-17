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
    internal class PgCtrlInfo
    {
        /// <summary>
        /// Specifies the file system location of the database files.
        /// If this is omitted, the environment variable PGDATA is used.
        /// </summary>
        /// <remarks>
        /// -D datadir
        /// </remarks>
        public string DataDir { get; set; }
    }
}

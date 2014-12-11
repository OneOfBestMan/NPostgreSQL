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
    public enum DataMode
    {
        All,
        /// <summary>
        /// Dump only the data, not the schema (data definitions). Table data, large objects, and sequence values are dumped.
        /// This option is similar to, but for historical reasons not identical to, specifying --section=data.
        /// </summary>
        DataOnly,
        /// <summary>
        /// Dump only the object definitions (schema), not data.
        /// This option is the inverse of --data-only. It is similar to, but for historical reasons not identical to, specifying --section=pre-data --section=post-data.
        /// (Do not confuse this with the --schema option, which uses the word "schema" in a different meaning.)
        /// To exclude table data for only a subset of tables in the database, see --exclude-table-data.
        /// </summary>
        SchemaOnly
    }
}

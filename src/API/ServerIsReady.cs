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
    public enum ServerIsReady
    {
        Ready = 0,      // 0 to the shell if the server is accepting connections normally
        Rejecting = 1,  // 1 if the server is rejecting connections (for example during startup)
        NoResponse = 2, // 2 if there was no response to the connection attempt
        NoAttempt = 3   // 3 if no attempt was made (for example due to invalid parameters)
    }
}

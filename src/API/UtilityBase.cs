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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    abstract class UtilityBase
    {
        public string ExecutablePath { get; set; }
        public string ExecutableFilename { get; set; }

        public void Execute(string arguments, string password = null)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.WorkingDirectory = ExecutablePath;
            processInfo.FileName = Path.Combine(ExecutablePath, ExecutableFilename);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;
            processInfo.Arguments = arguments;
            if (password != null)
                processInfo.EnvironmentVariables.Add("PGPASSWORD", password);

            Process process = new Process();
            process.StartInfo = processInfo;
            process.Start();

            string processError = process.StandardError.ReadToEnd();
            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                if (!process.HasExited)
                    process.Kill();

                throw new Exception(processError);
            }
        }
    }
}

using Renci.SshNet;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EdisonUploader
{
    /*
     * This class is responsible for actually connecting to and uploading the elf
     * file to the Intel Edison.
     * 
     * It relies on SSH.Net, install with nuget (Install-Package SSH.NET) or from 
     * Codeplex: https://sshnet.codeplex.com/
     * 
     * The basis for this script is to connect, move the old file, upload the new
     * file and then restart the service to it to run, this is based off the script
     * from here:
     * 
     * https://groups.google.com/a/arduino.cc/forum/#!topic/developers/vhFegYq5bAg
     * 
     */

    public class ElfUploader
    {
        private const string SKETCH_DIR = @"/sketch/";
        private const string SKETCH_FILE = @"sketch.elf";
        private const string SKETCH = SKETCH_DIR + SKETCH_FILE;
        private const string OLD_SKETCH = @"/sketch/sketch.elf.old";

        private string _host, _username, _password;

        public ElfUploader(string host, string username, string password)
        {
            _host = host;
            _username = username;
            _password = password;
        }

        /// <summary>
        /// Connect and Disconnect, if no exception is thrown it is successful.
        /// </summary>
        public void TestConnect()
        {
            using (var ssh = new SshClient(_host, _username, _password))
            {
                ssh.Connect();
                ssh.Disconnect();
            }
        }

        /// <summary>
        /// Connect to the Intel Edison and move the old file.
        /// </summary>
        public void MoveOldElfFile()
        {
            using (var ssh = new SshClient(_host, _username, _password))
            {
                ssh.Connect();
                using (var cmd = ssh.CreateCommand(string.Format("mv -f {0} {1}", SKETCH, OLD_SKETCH)))
                {
                    cmd.Execute();
                    // If there is no file to move and that caused the error ignore it.
                    if (cmd.ExitStatus != 0 && !cmd.Error.Contains("No such"))
                    {
                        throw new Exception(string.Format("Error running command '{0}', result = {1}", 
                            cmd.CommandText, cmd.Error));
                    }
                }
                ssh.Disconnect();
            }
        }

        /// <summary>
        /// Use SFTP to upload the file to the Intel Edison
        /// </summary>
        /// <param name="fileName">The full path to the local file to upload.</param>
        public void UploadeFile(string fileName)
        {
            using (var sftp = new SftpClient(_host, _username, _password))
            {
                sftp.Connect();
                sftp.ChangeDirectory(SKETCH_DIR);
                using (var uplfileStream = System.IO.File.OpenRead(fileName))
                {
                    sftp.UploadFile(uplfileStream, SKETCH_FILE, true);
                }
                sftp.Disconnect();
            }
        }

        /// <summary>
        /// Allow the newly uploaded file to be executable and then restart the clloader to run 
        /// the sketch.
        /// </summary>
        public void SetPermissionsAndRestart()
        {
            using (var ssh = new SshClient(_host, _username, _password))
            {
                ssh.Connect();
                using (var cmd = ssh.CreateCommand(string.Format("chmod +x {0}", SKETCH)))
                {
                    cmd.Execute();
                    if (cmd.ExitStatus != 0)
                    {
                        throw new Exception(string.Format("Error running command '{0}', result = {1}", 
                            cmd.CommandText, cmd.Error));
                    }
                }
                using (var cmd = ssh.CreateCommand("systemctl restart clloader"))
                {
                    cmd.Execute();
                    if (cmd.ExitStatus != 0)
                    {
                        throw new Exception(string.Format("Error running command '{0}', result = {1}", 
                            cmd.CommandText, cmd.Error));
                    }
                }
                ssh.Disconnect();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    class DeviceFile
    {
        // variables
        public string Name { get; }
        public int Size { get; set; }
        //constructor
        public DeviceFile(string n, int s)
        {
            Size = s;
            Name = n;
        }
        //methods
    }

    class DeviceDirectory
    {
        //variables

        public string Name { get; }
        public int Size { get; set; }
        public DeviceDirectory? parentDirectory;
        public List<DeviceFile> files;
        public List<DeviceDirectory> directories;
        // constructor
        public DeviceDirectory(string n, DeviceDirectory? pf)
        {
            parentDirectory = pf;
            Name = n;
            Size = 0;
            files = new List<DeviceFile>();
            directories = new List<DeviceDirectory>();
        }
        //methods
        public DeviceDirectory? getParentDirectory() { return parentDirectory;}
        public List<DeviceDirectory> getDirectories() { return directories; }
        public List<DeviceFile> getFiles() { return files; }
        public void AddDirectory(DeviceDirectory df){ directories.Add(df); }
        public void AddFile(DeviceFile df) { files.Add(df);}

        public void updateTotalSize()
        {
            int filesSize = 0;
            foreach(DeviceFile df in files)
            {
                filesSize += df.Size;
            }

            int directoriesSize = 0;
            foreach (DeviceDirectory df in directories)
            {
                directoriesSize += df.Size;
            }

            Size = (filesSize + directoriesSize);

        }

    }

}

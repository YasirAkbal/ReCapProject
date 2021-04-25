using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class FileDto
    {
        public string dir;
        public string name;
        public string extension;

        public FileDto(string dir, string name, string extension)
        {
            this.dir = dir;
            this.name = name;
            this.extension = extension;
        }

        public FileDto(string dir, string nameAndExtension)
        {
            this.dir = dir;

            var split = nameAndExtension.Split(".");
            this.name = split[0];
            this.extension = split[1];
        }

        public FileDto(string fullpath)
        {
            var splitForSlash = fullpath.Split("\\");
            this.dir = string.Join("\\", splitForSlash.Take(splitForSlash.Length-1));

            var splitForDot = splitForSlash.Last().Split(".");
            this.name = splitForDot[0];
            this.extension = splitForDot[1];
        }

        public string FullPath {
            get 
            {
                return string.Join("\\",dir,NameAndExtension);
            }
        }

        public string NameAndExtension
        {
            get
            {
                return string.Join(".", name, extension);
            }
        }
    }
}

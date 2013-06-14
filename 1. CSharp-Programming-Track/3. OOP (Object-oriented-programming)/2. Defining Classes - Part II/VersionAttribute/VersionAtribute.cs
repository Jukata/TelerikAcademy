using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionAttribute
{
    [AttributeUsage(AttributeTargets.Struct |
    AttributeTargets.Class |
    AttributeTargets.Interface |
    AttributeTargets.Enum |
    AttributeTargets.Method)]
    class Version : Attribute
    {
        private string edition;
        private int major;
        private int minor;
        public Version(int major, int minor)
        {
            this.major = major;
            this.minor = minor;
        }
        public string Edition
        {
            get
            {
                return major + "." + minor;
            }
        }
    }
}

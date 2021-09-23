using Microsoft.EntityFrameworkCore;

namespace Data
{
    [Keyless]
    public class CourseType
    {
        public string Unspecified { get; set; }
        public string Theory { get; set; }
        public string Driving { get; set; }

    }
}

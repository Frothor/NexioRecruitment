using System;

namespace Nexio.Models
{
    public interface IPerson
    {
        string Name { get;  set; }
        float Height { get; set; }
        DateTime DateOfBirth { get; set; }
        string EyeColor { get; set; }
    }
}

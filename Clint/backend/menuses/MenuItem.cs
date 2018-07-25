using System;

namespace Clint.backend.menuses
{
    class MenuItem
    {
        public int Id { get; set; }
        public String Entry { get; set; }

        public string asMenuEntry()
        {
            return $"{Id}) {Entry}";
        }
    }
}

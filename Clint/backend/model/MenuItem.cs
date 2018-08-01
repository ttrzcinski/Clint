using System;

namespace Clint.backend.model
{
    // Represents a single menu item from any menu.
    /// <summary>
    /// Represents a single menu item from any menu.
    /// </summary>
    public class MenuItem
    {
        public int Id { get; set; }
        public String Entry { get; set; }

        // Retruns concatenated form of entry with bracket after id.
        /// <summary>
        /// Retruns concatenated form of entry with bracket after id.
        /// </summary>
        /// <returns>id) entry</returns>
        public string asMenuEntry()
        {
            return $"{Id}) {Entry}";
        }
    }
}

namespace Clint.backend.workers
{
    public class FileWorker
    {
        // Variables
        //TODO Change it to list of last commands making it a historization
        /// <summary>
        /// Holds last used command for checks.
        /// </summary>
        private string _lastCommand;
        
        // Constructors
        
        // Inner methods
        
        // Interface methods
        
        /// <summary>
        /// Creates files and directories based on given list to tokenize.
        /// </summary>
        /// <param name="fileNames">line of file names and directories to tokenize</param>
        /// <returns>true, if all were created, false otherwise</returns>
        public bool Create(string fileNames)
        {
            // TODO Call OS to create a file with console 
            // TODO create empty files - for now
            
            
            
            return false;
        }

        /// <summary>
        /// Parses list of tuples to change from to and changes those file's names one by one.
        /// </summary>
        /// <param name="filesToChange">list with tuples of files to change name</param>
        /// <returns>true, if worked for every file, false otherwise</returns>
        public bool Rename(string filesToChange)
        {
            // TODO Call OS to rename a file with console 
            return false;
        }

        /// <summary>
        /// Removes files and directories based on given list to tokenize.
        /// </summary>
        /// <param name="fileNames">line of file names and directories to tokenize</param>
        /// <returns>true, if all were removed, false otherwise</returns>
        public bool Remove(string fileNames)
        {
            // TODO Call OS to remove a file with console 
            return false;
        }

        /// <summary>
        /// Reports about current location info.
        /// </summary>
        /// <param name="filters">filters information just to wanted params</param>
        /// <returns>report with wanted information</returns>
        public string CurrentLocationReport(string filters)
        {
            // TODO Call OS to show info about files with console 
            return null;
        }

        // Accessors
        public string LastCommand
        {
            get => _lastCommand ?? "(There was none yet.)";
        }
    }
}
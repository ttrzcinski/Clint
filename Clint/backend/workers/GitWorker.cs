using System.IO;
using Clint.backend.enums;

namespace Clint.backend.workers
{
    /// <summary>
    /// Wraps around series of commands in git to make it easier to use.
    /// </summary>
    class GitWorker
    {
        //Inner variables with fast accessors
        // TODO Add question about login in order to keep it as a catalog in GitHub
        private string _login;
        // TODO Add in cache last command (or even history of commands) in order to f.e. repeat them
        private string _lastCommand;
        // TODO Flag for auto commit after change to wanted level - off, auto commit, auto commit and push, auto commit and push with force
        public AutoCommit AutoCommit { get; set; }
        // TODO Keeps current location as a project/solution
        private string _currentLocation;
        /// <summary>
        /// Current location of project, over which works GitWorker.
        /// </summary>
        public string CurrentLocation
        {
            get => _currentLocation;
            set => _currentLocation = value;
        }

        //Constructors
        GitWorker(string login, string location, AutoCommit autoCommit = AutoCommit.Off)
        {
            _currentLocation = string.IsNullOrEmpty(location) ? location : Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            
            _login = login;

            AutoCommit = autoCommit;
        }

        //Inner methods

        //API methods
        public void Init()
        {
            // TODO Ask for login OR read it from global
            
            // TODO Read current location
            
            // TODO Check, if there is already git repo initialized in current folder
            
            // TODO Call console with git init
            
            // TODO Call console with git remote add origin remote "https://github.com/{githublogin}/{projectname}.git"
            
            // TODO Call for console to verify git remote -v
            
            // TODO Call console with git add .
            
            // TODO Call console with git commit -m "Initialized with Clint."
            
            // TODO Call console with git push origin master
        }

        public void Sync(bool mine = false)
        {
            // TODO Assure, that there is .git and it is initialized
            
            // TODO Call console with git fetch
            
            // TODO Compare, if in fetch there is something in collision with things changes in status
            
            // TODO if mine is null, Call console with git pull
        }

        public void Add(string fileNames)
        {
            // TODO Assure, that there is .git and it is initialized
            
            // TODO Check, if there are some files to add with git status or git diff
            
            // TODO if fileNames given, Call console with git add {fileNames}
            // TODO else, Call console with git add .
            
            // TODO Prepare list of added files into a comment
            
            // TODO Call console with git commit -m "Added files:\n{file_1}\n{file_2}.."
            
            // TODO Call console with git push
        }

        public void CreateFile(string name, string content, string location) {
            // TODO Fix location with current, if empty

            // TODO CHECK EXISTENCE OF FILE WITH SUCH A FULL PATH
        }

        public void RemoveFileOrDirectory(string filename, string location, bool fromDisk = true) {
            // TODO Ask about everything before acting on your own
            
            // TODO Check, if removed thing is a file or a directory
            
            // TODO if file, Call console with git rm --cached filename
            
            // TODO if directory, Call console with git rm --cached -r filename

            // TODO Call console with git commit -m "Removed file:\n{file_1}"
            
            // TODO Call console with git push

            // TODO if directory, Call console with (depending of OS) rm -f filename
        }

        public void Commit(string message)
        {
            // TODO check, if there is something to commit actually
            
            // TODO Call console with git commit -m {message}
        }

        public void Push(bool force = false)
        {
            // TODO check, if there is something to push actually (was committed and hangs0
            
            // TODO Check, is remote git repo is set
            
            // TODO Call console with git push
        }

        public void merge(string branchName)
        {
            // TODO Read name of current branch

            // TODO Check, if there will be some errors with merging

            // TODO Call the console to merge

            // TODO Refresh current repo with fetch, status, pull
        }

        //Accessors
        /*public void Auto(AutoCommit flag)
        {
            //Set AutoCommit to wanted level - off, auto commit, auto commit and push, auto commit and push with force 
            _autoCommit = flag;
        }

        /// <summary>
        /// Returns current level of autoCommit flag.
        /// </summary>
        /// <returns>off, auto commit, auto commit and push or auto commit and push with force</returns>
        public AutoCommit Auto()
        {
            return _autoCommit;
        }*/

        /// <summary>
        /// Returns last kept Command.
        /// </summary>
        /// <returns>command, if was used, brackets, if not</returns>
        public string LastCommand
        {
            get => _lastCommand ?? "(There was none yet.)";
        }
    }
}
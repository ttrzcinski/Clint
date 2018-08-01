//THIS CLASS WITH BE USED TO WRAP GIT COMMANDS AND CALL THE MFROM CURRENT DIRECTORY OR POINTED LOCATION
using System;
using Clint.backend.enums;

namespace Clint
{
    /*  */
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

        //Constructors
        GitWorker(string login, string location, AutoCommit autoCommit)
        {
            _login = login;

            _currentLocation = location;
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

        public void Sync()
        {
            // TODO Assure, that there is .git and it is initialized
            
            // TODO Call console with fetch
            
            // TODO 
        }

        public void AddAll()
        {
            // TODO Assure, that there is .git and it is initialized
            
            // TODO Check, if there are some files to add with git status or git diff
            
            // TODO Call console with git add .
            
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

        public void PushMyChanges(bool force = false)
        {
            
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
        /// 
        /// </summary>
        /// <returns></returns>
        public string LastCommand()
        {
            return _lastCommand ?? "(There was none yet.)";
        }
    }
}
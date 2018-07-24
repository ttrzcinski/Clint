//THIS CLASS WITH BE USED TO WRAP GIT COMMANDS AND CALL THE MFROM CURRENT DIRECTORY OR POINTED LOCATION
using System;

namespace Clint
{
    /*  */
    class Gitworker
    {
        //Inner variables with fast accessors
        private String lastCommand;
        private String currentLocation;

        //Constructors

        //Inner methods

        //API methods
        public void createFile(String name, String content, String location) {
            //Fix location with current, if empty

            //CHECK EXISTENCE OF FILE WITH SUCH A FULL PATH
        }

        public void removeFile(String name, String location) {
            //Ask about everything before acting on your own
        }
    }
}
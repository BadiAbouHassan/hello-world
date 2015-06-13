using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class UserController
    {
         private UserService userService;
        public UserController()
        {
            this.userService= new UserService() ;
        }

        public Boolean addUser(User user)
        {
            return this.userService.addUser(user);
        }

        public List<User> getUsers(int userID= 0)
        {
            return this.userService.getUsers(userID);
        }

        public User checkUserAuthentication(String username , String password)
        {
            return this.userService.checkUserAuthentication(username, password);
        }

        public User getUserByID(int ID)
        {
            return this.userService.getUserByID(ID);
        }


    }
}
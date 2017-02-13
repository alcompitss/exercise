using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi1.Models
{
    public class UserInfo
    {
        private string _UserCode = string.Empty;
        private string _FirstName = string.Empty;
        private string _LastName = string.Empty;
        private string _JobTitle = string.Empty;

        public string JobTitle
        {
            get { return _JobTitle; }
            set { _JobTitle = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }


        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }


        public string UserCode
        {
            get { return _UserCode; }
            set { _UserCode = value; }
        }


    }


    public class users
    {
        private static users instance = null;
        private static readonly object padlock = new object();

        private users()
        {
        }

        public static users Instance()
        {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new users();

                        instance.Add(new UserInfo() { UserCode = "U0001", FirstName = "John", LastName = "Peter", JobTitle = "Technology Lead" });
                        instance.Add(new UserInfo() { UserCode = "U0002", FirstName = "Kannan", LastName = "Peter", JobTitle = "Senoir Developr" });

                    }
                    return instance;
                }
        }

        private List<UserInfo> _List = new List<UserInfo>();
        public List<UserInfo> List
        {
            get
            {
                return _List;
            }
        }

        public void Add(UserInfo _user)
        {
            _List.Add(_user);
        }

        public void Update(string _Ucode ,UserInfo _user)
        {
            var user = _List.Where(u => u.UserCode == _Ucode).FirstOrDefault();
            if (user != null) { user.FirstName = _user.FirstName; user.LastName = _user.LastName; user.JobTitle = _user.JobTitle; }
        }

        public void Delete(string _Ucode)
        {
            var user = _List.Where(u => u.UserCode == _Ucode).FirstOrDefault();

            if (user != null) { _List.Remove(user); }
        }

    }

}
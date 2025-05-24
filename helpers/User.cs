using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBBA.helpers
{
    public class User
    {
        int userId = -1;
        string email = "";
        string password = "";
        string firstName = "";
        string lastName = "";
        string birthday = "";
        string gender = "";
        int tz = 0;
        bool isPlayer = false;
        public int GetUserId()
        {
            return userId;
        }
        public string GetEmail()
        {
            return email;
        }
        public string GetPassword()
        {
            return password;
        }
        public string GetFirstName()
        {
            return firstName;
        }
        public string GetLastName()
        {
            return lastName;
        }
        public string GetBirthday()
        {
            return birthday;
        }
        public string GetGender()
        {
            return gender;
        }
        public int GetTz()
        {
            return tz;
        }
        public bool IsPlayer()
        {
            return isPlayer;
        }
        public void SetUserId(int id)
        {
            userId = id;
        }
        public void SetUserName(string emaill)
        {
            email = emaill;
        }
        public void SetPassword(string pass)
        {
            password = pass;
        }
        public void SetFirstName(string name)
        {
            firstName = name;
        }
        public void SetLastName(string name)
        {
            lastName = name;
        }
        public void SetBirthday(string date)
        {
            birthday = date;
        }
        public void SetGender(string genderr)
        {
            gender = genderr;
        }
        public void SetTz(int tzz)
        {
            tz = tzz;
        }
        public void SetPlayer(bool player)
        {
            isPlayer = player;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch
{
    public class UserDetailsLogic : BaseLogic
    {

        //Get list of all users details
        public List<UserDetailsModel> GetAllUserDetails()
        {
            var query = from d in DB.UsersDetails
                        select new UserDetailsModel
                        {
                            id = d.UserID,
                            fullName = d.FullName,
                            userName = d.UserName,
                            password = d.Password,
                            email = d.Email,
                            birthDate = d.BirthDate

                        };


            return query.ToList();
        }

        public UserDetailsModel GetUserID(string username)
        {
            return DB.UsersDetails
                .Where(d => d.UserName == username)
                .Select(d => new UserDetailsModel
                {
                    id = d.UserID,
                    userName = d.UserName,
                    password = d.Password,
                    email = d.Email,
                    birthDate = d.BirthDate
                }).SingleOrDefault();
        }


        //Add new user
        public UserDetailsModel AddNewUser(UserDetailsModel userDetailModel)
        {


            UsersDetail userdetail = DB.UsersDetails.FirstOrDefault(u => (u.UserName == userDetailModel.userName || u.Password == userDetailModel.password));
            if (userdetail == null)
            {
                UsersDetail userDetail = new UsersDetail
                {

                    FullName = userDetailModel.fullName,
                    UserName = userDetailModel.userName,
                    Password = userDetailModel.password,
                    Email = userDetailModel.email,
                    BirthDate = userDetailModel.birthDate
                };
                DB.UsersDetails.Add(userDetail);
                DB.SaveChanges();
                userDetailModel.id = userDetail.UserID;
                return userDetailModel;
            }
            else
                return null;
        }

        public UserDetailsModel Login(UserDetailsModel userDetailModel)
        {


            UsersDetail userdetail = DB.UsersDetails.FirstOrDefault(u => (u.UserName == userDetailModel.userName && u.Password == userDetailModel.password));
            if (userdetail != null)
            {

                return userDetailModel;
            }
            else
                return null;
        }

    }
}

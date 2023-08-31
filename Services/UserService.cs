using Microsoft.AspNetCore.Mvc;
using core7_mvc_mssql.Data;
using core7_mvc_mssql.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;

namespace core7_mvc_mssql.Services {

    public interface IUserService {
        int addUser(UserProfile userProfile);
        UserProfile GetUserById(string idno);
    }

    public class UserService : IUserService {

        private IdentityDataContext _context;


        public UserService(IdentityDataContext context)
        {
            _context = context;
        }

        public int addUser(UserProfile userdata) {
         try {
           var findId = _context.UserProfiles.Where(u => u.Userid == userdata.Userid).FirstOrDefault();
           if (findId.Userid is not null) {
                findId.Lastname = userdata.Lastname;
                findId.Firstname = userdata.Firstname;
                findId.Mobile = userdata.Mobile;
                if(userdata.Userpic is not null) {
                   findId.Userpic = userdata.Userpic;
                }
                _context.UserProfiles.Update(findId);
                _context.SaveChanges();
                return 2;
           } 
         } catch(Exception) {

            _context.UserProfiles.Add(userdata);
            _context.SaveChanges();
            Console.WriteLine("added....");
            return 1;
         }
           return 0;
        }

        public UserProfile GetUserById(string id) {
            return _context.UserProfiles.Where(u => u.Userid == id).FirstOrDefault();
        }
    }

}


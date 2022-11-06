using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(int user) => MemberDAO.Instance.Delete(user);

        public IEnumerable<string> GetMemberIDs() => MemberDAO.Instance.GetUsersID();

        public void InsertMember(MemberObject user) => MemberDAO.Instance.Create(user);

        public IEnumerable<MemberObject> GetMembers() => MemberDAO.Instance.GetUsers();

        public MemberObject Login(string email, string password) => MemberDAO.Instance.Login(email, password);

        public void UpdateMember(MemberObject user) => MemberDAO.Instance.Update(user);
    }
}

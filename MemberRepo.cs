using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoginLabTask.Models;

namespace LoginLabTask
{
    public class MemberRepo
    {
        public bool MemberLogin(MemberModel memberModel)
        {
            using (var context = new LabTaskEntities())
            {
                var IsValid = context.Member.FirstOrDefault(x => x.UserName == memberModel.UserName);

                if (IsValid != null)
                {
                    if (IsValid.Password == memberModel.Password)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        public int AddMember(MemberModel memberModel)
        {
            using (var context = new LabTaskEntities())
            {
                Member member = new Member()
                {
                    UserName = memberModel.UserName,
                    Password = memberModel.Password,
                };

                context.Member.Add(member);
                context.SaveChanges();
                return member.Id;
            }
        }
    }
}
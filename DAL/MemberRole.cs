//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookKeeperNewJosh.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MemberRole
    {
        public string memberRoleID { get; set; }
        public string studentNo { get; set; }
        public string roleID { get; set; }
    
        public virtual MemberRole MemberRole1 { get; set; }
        public virtual MemberRole MemberRole2 { get; set; }
        public virtual Role Role { get; set; }
    }
}
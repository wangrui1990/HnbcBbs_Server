using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using HnbcInfo.Bbs.Authorization.Roles;
using HnbcInfo.Bbs.Authorization.Users;
using HnbcInfo.Bbs.MultiTenancy;
using HnbcInfo.Bbs.Bbs;
using HnbcInfo.Bbs.Bbs.Topics;
using HnbcInfo.Bbs.Bbs.Nodes;
using HnbcInfo.Bbs.Bbs.Likes;
using HnbcInfo.Bbs.Bbs.Replies;

namespace HnbcInfo.Bbs.EntityFrameworkCore
{
    public class BbsDbContext : AbpZeroDbContext<Tenant, Role, User, BbsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Node> Nodes { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        
        public BbsDbContext(DbContextOptions<BbsDbContext> options)
            : base(options)
        {
        }
    }
}

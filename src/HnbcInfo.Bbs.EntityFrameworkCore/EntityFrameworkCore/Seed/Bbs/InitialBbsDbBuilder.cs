using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.EntityFrameworkCore.Seed.Bbs
{
    public class InitialBbsDbBuilder
    {
        private readonly BbsDbContext _context;

        public InitialBbsDbBuilder(BbsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            //new DefaultEditionCreator(_context).Create();
            //new DefaultLanguagesCreator(_context).Create();
            //new HostRoleAndUserCreator(_context).Create();
            //new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}

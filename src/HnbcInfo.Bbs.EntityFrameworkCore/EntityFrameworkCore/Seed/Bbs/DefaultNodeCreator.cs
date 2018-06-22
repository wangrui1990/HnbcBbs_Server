using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HnbcInfo.Bbs.EntityFrameworkCore.Seed.Bbs
{
    public class DefaultNodeCreator
    {
        private readonly BbsDbContext _context;

        public DefaultNodeCreator(BbsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateNodes();
        }

        private void CreateNodes()
        {
            var defaultEdition = _context.Nodes.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                _context.Editions.Add(defaultEdition);
                _context.SaveChanges();

                /* Add desired features to the standard edition, if wanted... */
            }
        }

        private void CreateFeatureIfNotExists(int editionId, string featureName, bool isEnabled)
        {
            if (_context.EditionFeatureSettings.IgnoreQueryFilters().Any(ef => ef.EditionId == editionId && ef.Name == featureName))
            {
                return;
            }

            _context.EditionFeatureSettings.Add(new EditionFeatureSetting
            {
                Name = featureName,
                Value = isEnabled.ToString(),
                EditionId = editionId
            });
            _context.SaveChanges();
        }
    }
}

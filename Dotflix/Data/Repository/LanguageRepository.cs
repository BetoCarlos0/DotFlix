﻿using Dotflix.Models;
using Dotflix.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotflix.Data.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly DotflixDbContext _dbContext;

        public LanguageRepository(DotflixDbContext dotflixDbContext)
        {
            _dbContext = dotflixDbContext;
        }

        public async Task<IEnumerable<Language>> GetAllAsync()
        {
            return await _dbContext.Language
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Language> GetByIdAsync(Guid id)
        {
            return await _dbContext.Language
                .FindAsync(id);
        }

        public async Task<Language> GetByNameAsync(string name)
        {
            return await _dbContext.Language.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }

        public async Task<bool> AddAsync(Language language)
        {
            await _dbContext.Language.AddAsync(language);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Language> UpdateAsync(Language language)
        {
            var getLanguage = await _dbContext.Language.
                FirstOrDefaultAsync(x => x.LanguageId.Equals(language.LanguageId));
            
            if (getLanguage == null) return null;

            getLanguage.Name = language.Name;

            await _dbContext.SaveChangesAsync();

            return getLanguage;
        }

        public async Task<bool> DeleteId(Guid id)
        {
            var getLanguage = await _dbContext.Language.
                FirstOrDefaultAsync(x => x.LanguageId == id);

            if (getLanguage != null)
            {
                _dbContext.Remove(getLanguage);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

    }
}

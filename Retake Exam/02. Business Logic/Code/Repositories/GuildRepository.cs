using System;
using System.Collections.Generic;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using LegendsOfValor_TheGuildTrials.Models.Contracts;

namespace Repositories
{
    public class GuildRepository : IRepository<IGuild>
    {
        private readonly List<IGuild> guilds;

        public GuildRepository()
        {
            guilds = new List<IGuild>();
        }

        public void AddModel(IGuild guild)
        {
            guilds.Add(guild);
        }

        public IGuild GetModel(string guildName)
        {
            return guilds.Find(g => g.Name == guildName);
        }

        public IReadOnlyCollection<IGuild> GetAll()
        {
            return guilds.AsReadOnly();
        }
    }
} 
﻿using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Services.EFService
{
    public class EFDevTeamService: IDevTeamService
    {
        private HGDBContext context;
        public EFDevTeamService(HGDBContext service)
        {
            context = service;
        }

        public void CreateDevTeam(DevTeam team)
        {
            context.DevTeams.Add(team);
            context.SaveChanges();
        }

        public IEnumerable<DevTeam> GetDevTeams()
        {
            return context.DevTeams
                .Include(t => t.Employees)
                    .ThenInclude(e => e.Role)
                .Include(t => t.TeamManagers)
                    .ThenInclude(tm => tm.Game);               
        }

        public void UpdateDevTeam(DevTeam devT)
        {
            var existingDevTeam = context.DevTeams.FirstOrDefault(t => t.DevTeamId == devT.DevTeamId);
            
                // Update the fields as needed
                existingDevTeam.DevTname = devT.DevTname;
                context.SaveChanges();
        }

        public IEnumerable<DevTeam> TeamSearch(string SearchString)
        {
            return context.DevTeams
                .Include(t => t.Employees)
                .Where(t => t.DevTname.Contains(SearchString) 
                    || t.Employees.Any(e => e.FirstName.Contains(SearchString) 
                    ||  e.LastName.Contains(SearchString)));
        }

        public void ConnectTeamWithGame(int teamId, int gameId)
        {
            var teamManager = new TeamManager
            {
                DevTeamId = teamId,
                GameId = gameId
            };
            context.TeamManagers.Add(teamManager);
            context.SaveChanges();
        }

        public bool DevTeamExists(int id)
        {
            return context.DevTeams.Any(e => e.DevTeamId == id);
        }
    }
}

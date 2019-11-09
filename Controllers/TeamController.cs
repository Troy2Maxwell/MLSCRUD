using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLS_CRUD.Models;

namespace MLS_CRUD.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            var repo = new TeamRepository();
            List<Team> teams = repo.GetTeams();

            return View(teams);
        }

        public IActionResult ViewTeam(int id)
        {
            var repo = new TeamRepository();
            Team team = new TeamRepository().GetTeam(id);

            return View(team);
        }

        public IActionResult ViewEastTeams()
        {
            var repo = new TeamRepository();
            List<Team> eteams = repo.GetEastTeams();

            return View(eteams);
        }

        public IActionResult ViewWestTeams()
        {
            var repo = new TeamRepository();
            List<Team> wteams = repo.GetWestTeams();

            return View(wteams);
        }

        public IActionResult InsertTeam()
        {
            var repo = new TeamRepository();
            //var team = repo.GetTeams();

            return View();
        }
        public IActionResult InsertTeamToDatabase(Team teamToInsert)
        {
            var repo = new TeamRepository();
            repo.InsertTeam(teamToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteTeamFromDatabase(Team teamToDelete)
        {
            var repo = new TeamRepository();
            repo.DeleteTeam(teamToDelete.TeamName);

            return RedirectToAction("Index");
        }

        public IActionResult UpdateTable(int id)
        {
            var repo = new TeamRepository();
            var team = repo.GetTeam(id);

            return View(team);
        }

        public IActionResult UpdateTeamToDataBase(Team team)
        {
            var repo = new TeamRepository();
            repo.UpdateTeam(team);

            return RedirectToAction("Index");
        }
    }
}
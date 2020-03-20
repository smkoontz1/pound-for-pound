using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using PoundForPound.Models;

namespace PoundForPound.Data
{
    public static class TeamRosterService
    {
        public static readonly List<Team> Teams = new List<Team>
        {
            new Team
            {
                Id = 1,
                DisplayName = "Nebraska Cornhuskers",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/158/nebraska-cornhuskers",
            },
            new Team
            {
                Id = 2,
                DisplayName = "Iowa Hawkeyes",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/2294/iowa-hawkeyes",
            }
        };

        public static double GetTeamWeight(int id)
        {
            double _teamWeight = 0;
            
            Team _team = Teams.Where(t => t.Id == id).FirstOrDefault();
            string _teamHtml = GetRawHtml(_team.RosterUrl);

            Regex _teamHtmlOffenseRegex = new Regex(@"<section class=""ResponsiveTable Offense"">.*?</section>");

            string _teamOffense = _teamHtmlOffenseRegex.Match(_teamHtml).Value;

            Regex _weightRegex = new Regex(@"(\d{1,3}) lbs</span>", RegexOptions.Multiline);

            MatchCollection _matches = _weightRegex.Matches(_teamOffense);

            Console.WriteLine(_matches.Count());

            foreach (Match _match in _matches)
            {
                Console.WriteLine(_match.Groups[1].Value);
                _teamWeight += double.Parse(_match.Groups[1].Value);
            }

            return _teamWeight;
        }

        private static string GetRawHtml(string url)
        {
            using (WebClient _client = new WebClient())
            {
                return _client.DownloadString(url);
            }
        }
    }
}
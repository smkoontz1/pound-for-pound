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

        private static Regex _offenseRegex = new Regex(@"<section class=""ResponsiveTable Offense"">.*?</section>");

        private static Regex _defenseRegex = new Regex(@"<section class=""ResponsiveTable Defense"">.*?</section>");
        
        private static Regex _specialTeamsRegex = new Regex(@"<section class=""ResponsiveTable Special Teams"">.*?</section>");

        private static Regex _weightRegex = new Regex(@"(\d{1,3}) lbs</span>", RegexOptions.Multiline);

        public static readonly List<Team> Teams = new List<Team>
        {
            new Team
            {
                Id = 1,
                DisplayName = "Illinois Fighting Illini",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/356/illinois-fighting-illini",
            },
            new Team
            {
                Id = 2,
                DisplayName = "Indiana Hoosiers",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/84/indiana-hoosiers",
            },
            new Team
            {
                Id = 3,
                DisplayName = "Maryland Terrapins",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/120/maryland-terrapins",
            },
            new Team
            {
                Id = 4,
                DisplayName = "Michigan State Spartans",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/127/michigan-state-spartans",
            },
            new Team
            {
                Id = 5,
                DisplayName = "Michigan Wolverines",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/130/michigan-wolverines",
            },
            new Team
            {
                Id = 6,
                DisplayName = "Minnesota Golden Gophers",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/135/minnesota-golden-gophers",
            },
            new Team
            {
                Id = 7,
                DisplayName = "Nebraska Cornhuskers",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/158/nebraska-cornhuskers",
            },
            new Team
            {
                Id = 8,
                DisplayName = "Northwestern Wildcats",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/77/northwestern-wildcats",
            },
            new Team
            {
                Id = 9,
                DisplayName = "Iowa Hawkeyes",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/2294/iowa-hawkeyes",
            },
            new Team
            {
                Id = 10,
                DisplayName = "Ohio State Buckeyes",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/194/ohio-state-buckeyes",
            },
            new Team
            {
                Id = 11,
                DisplayName = "Penn State Nittany Lions",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/213/penn-state-nittany-lions",
            },
            new Team
            {
                Id = 12,
                DisplayName = "Purdue Boilermakers",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/2509/purdue-boilermakers",
            },
            new Team
            {
                Id = 13,
                DisplayName = "Rutgers Scarlet Knights",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/164/rutgers-scarlet-knights",
            },
            new Team
            {
                Id = 14,
                DisplayName = "Wisconsin Badgers",
                RosterUrl = "https://www.espn.com/college-football/team/roster/_/id/275/wisconsin-badgers",
            },
        };

        public static double GetWeightInLbs(Team team, TeamDivision teamDivision, string teamRawHtml)
        {
            double _weight = 0;

            string _teamUrl = Teams.Where(t => t == team).FirstOrDefault().RosterUrl;

            string _divisionHtml = teamDivision switch
            {
                TeamDivision.Offense => _offenseRegex.Match(teamRawHtml).Value,
                TeamDivision.Defense => _defenseRegex.Match(teamRawHtml).Value,
                TeamDivision.SpecialTeams => _specialTeamsRegex.Match(teamRawHtml).Value,
                _ => null,
            };

            MatchCollection _weightMatches = _weightRegex.Matches(_divisionHtml);

            foreach (Match _weightMatch in _weightMatches)
            {
                _weight += double.Parse(_weightMatch.Groups[1].Value);
            }

            return _weight;
        }

        public static Team GetTeamById(int id)
        {
            return Teams.Where(t => t.Id == id).FirstOrDefault();
        }

        public static string GetRawHtml(string url)
        {
            using (WebClient _client = new WebClient())
            {
                return _client.DownloadString(url);
            }
        }
    }
}
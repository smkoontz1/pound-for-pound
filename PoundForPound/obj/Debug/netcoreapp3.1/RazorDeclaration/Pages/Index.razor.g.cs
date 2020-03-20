#pragma checksum "C:\_git\pound-for-pound\PoundForPound\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9264ed55db9689d001cf075305a04ef5a3c1bba0"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace PoundForPound.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\_git\pound-for-pound\PoundForPound\_Imports.razor"
using System.Net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\_git\pound-for-pound\PoundForPound\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\_git\pound-for-pound\PoundForPound\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\_git\pound-for-pound\PoundForPound\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\_git\pound-for-pound\PoundForPound\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\_git\pound-for-pound\PoundForPound\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\_git\pound-for-pound\PoundForPound\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\_git\pound-for-pound\PoundForPound\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\_git\pound-for-pound\PoundForPound\_Imports.razor"
using PoundForPound;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\_git\pound-for-pound\PoundForPound\_Imports.razor"
using PoundForPound.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\_git\pound-for-pound\PoundForPound\_Imports.razor"
using PoundForPound.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\_git\pound-for-pound\PoundForPound\_Imports.razor"
using PoundForPound.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 25 "C:\_git\pound-for-pound\PoundForPound\Pages\Index.razor"
       
    private int _team1Id = 1;
    
    private int _team2Id = 2;

    private double _team1Weight = 0;

    private double _team2Weight = 0;

    protected override void OnInitialized()
    {
        Console.WriteLine("OnInitialized hit.");
        _team1Weight = TeamRosterService.GetTeamWeight(_team1Id);
        _team2Weight = TeamRosterService.GetTeamWeight(_team2Id);
    }

    private void UpdateTeam1Value(ChangeEventArgs args)
    {
        _team1Id = Int32.Parse(args.Value.ToString());
        _team1Weight = TeamRosterService.GetTeamWeight(_team1Id);
    }

    private void UpdateTeam2Value(ChangeEventArgs args)
    {
        _team2Id = Int32.Parse(args.Value.ToString());
        _team2Weight = TeamRosterService.GetTeamWeight(_team2Id);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { LeaguePageComponent } from './league-page/league-page.component';
import { TournamentDetailComponent } from './tournament-detail/tournament-detail.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { OngoingTournamentPageComponent } from './ongoing-tournament-page/ongoing-tournament-page.component';
import { PlayersPageComponent } from './players-page/players.component';
import { TablePageComponent } from './table-page/table-page.component';
import { MatIconModule } from '@angular/material/icon';
import { ArchiveTournamentComponent } from './archive-tournament/archive-tournament.component';

const routes: Routes = [
{path:'', component:HomepageComponent},
{path:'LogIn', component:LoginPageComponent},
{path:'League',component:LeaguePageComponent},
{path:'Tournament-Detail/:id',component:TournamentDetailComponent},
{path:'Ongoing-Tournament-Page/:id',component:OngoingTournamentPageComponent},
{path:'Players-Page',component:PlayersPageComponent},
{path:'Ongoing-Tournament-Page/:id/Tables',component:TablePageComponent},
{path:'Archive-Tournament-Page/:id',component:ArchiveTournamentComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes), BrowserModule, FormsModule, MatIconModule],
  exports: [RouterModule],
})
export class AppRoutingModule { }

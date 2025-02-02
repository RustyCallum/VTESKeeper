import { Component } from '@angular/core';

  interface leaguePlayers{
    lastName:string;
    firstName:string;
    VEKN:string;
    points:number;
  }

@Component({
  selector: 'app-league-page',
  templateUrl: './league-page.component.html',
  styleUrl: './league-page.component.css'
})
export class LeaguePageComponent {

  player:string = "";

  leaguePlayers: leaguePlayers[] = [
    {VEKN: '5144324', firstName: 'Jan', lastName: 'Dąbrowski', points: 3},
    {VEKN: '123512', firstName: 'Aleksander', lastName: 'Duda' ,points: 10},
    {VEKN: '21314', firstName: 'Rafał', lastName: 'Nowak',points: 5},
    {VEKN: '14234', firstName: 'Jan', lastName: 'Kowalski', points: 0},
  ];
  
}

import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { PlayersPagePopupComponent } from '../players-page-popup/players-page-popup.component';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

export interface Players{
  firstName:string;
  lastName:string;
  vekn:string;
  city:string;
  id:number;
}

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrl: './players.component.css'
})
export class PlayersPageComponent {

  private url = "Player";
  
  constructor(
    private router: Router,
    public dialog: MatDialog,
    private http: HttpClient) {

  }

  ngOnInit(): void {
    this.http.get<Players[]>(`${environment.apiPlayerUrl}`).subscribe(data => this.Players = data)
    
  }
    
  openDialog() {
    const dialogRef = this.dialog.open(PlayersPagePopupComponent, {
      data: { vekn: '', firstName: '', lastName: '', city: ''}
    });

    dialogRef.afterClosed().subscribe(result =>{
      if(result != '' && result != null){
        console.log(result);
        this.addPlayer(result);
      }
    })
  }

  addPlayer(formData: Players){
    this.http.post<Players>(`${environment.apiPlayerUrl}`, formData).subscribe(data => this.Players.push(data));
  }
  
  players:string = "";

  Players: Players[] = [];

  
}

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import { CreateTournamentPopupComponent } from '../create-tournament-popup/create-tournament-popup.component';
import { Tournament } from './tournament';
import { DialogRef } from '@angular/cdk/dialog';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { NotificationComponent } from '../notification/notification.component';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css',
})

export class HomepageComponent {
  private url = "Tournament";

  tourId!:number;

  constructor(
    private router: Router,
    public dialog: MatDialog,
    private http: HttpClient,
    private notifier: NotificationComponent) {

  }

  ngOnInit(): void {
    this.http.get<Tournament[]>(`${environment.apiTournamentUrl}`).subscribe(data => {this.tournaments = data})
  }

  cities: string[] = ['Warszawa', 'Lublin', 'Radom', 'Kraków', 'Szczecin'];
  uber:string = "";  
  playerNumber!: number;
  playerNumbers: number[] = [5, 10, 15, 20, 25, 30, 35];

  openDialog() {
    const dialogRef = this.dialog.open(CreateTournamentPopupComponent, {
      data: { name: '', city: '', date: ''}
    });

    dialogRef.afterClosed().subscribe(result =>{
      if(result != '' && result != null){
        console.log(result);
        this.http.post<Tournament>(`${environment.apiTournamentUrl}`, result).subscribe((response => {
          this.tourId = response.id
          this.router.navigateByUrl(`Ongoing-Tournament-Page/${this.tourId}`)
        }),
        error => {
          if(error.status === 401) {
            this.notifier.showNotification("Nie masz uprawnień do tej operacji", 'error')
          } 
        }
        );
      }
    })
  }

  openArchiveDialog() {
    const dialogRef = this.dialog.open(CreateTournamentPopupComponent, {
      data: { name: '', city: '', date: ''}
    });

    dialogRef.afterClosed().subscribe(result =>{
      if(result != '' && result != null){
        console.log(result);
        this.http.post<Tournament>(`${environment.apiTournamentUrl}`, result).subscribe((response => {
          this.tourId = response.id
          this.router.navigateByUrl(`Archive-Tournament-Page/${this.tourId}`)
        }),
        error => {
          if(error.status === 401) {
            this.notifier.showNotification("Nie masz uprawnień do tej operacji", 'error')
          } 
        }
        );
      }
    })
  }

  addTournament(formData: Tournament){

  }

  tournaments: Tournament[] = [
    //{name: 'Fee Stake: Lublin', city: 'Lublin', date: '03.10.23', playerNumber: 19, winner:'Damian Kowalski', deck: 'Legioniści', id: 2},
  ];

  public getTournaments() : Observable<Tournament[]>{

    return this.http.get<Tournament[]>(`${environment.apiTournamentUrl}`)
  }
}

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { OngoingTournamentPopupComponent } from '../ongoing-tournament-popup/ongoing-tournament-popup.component';
import { OngoingTournamentRollTablesPopupComponent } from '../ongoing-tournament-roll-tabels-popup/ongoing-tournament-roll-tabels-popup.component';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { Tournament } from '../homepage/tournament';
import { HttpClient } from '@angular/common/http';
import { Player } from '../ongoing-tournament-popup/player';
import { Deck } from './Deck';
import { TournamentPlayer } from './tournament-player';


@Component({
  selector: 'app-ongoing-tournament-page',
  templateUrl: './ongoing-tournament-page.component.html',
  styleUrl: './ongoing-tournament-page.component.css'
})
export class OngoingTournamentPageComponent {

  fileName!: string;
  result!:string;
  id!: number;

  playerForm!: FormGroup;
  playerList: any;

  constructor(
    private fb: FormBuilder,
    public dialog: MatDialog,
    private router: ActivatedRoute,
    private urlRouter: Router,
    private http: HttpClient)
    {
    this.playerList =[];

    this.playerForm = this.fb.group({
      vekn: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      playerCity: ['', Validators.required],
      playerDeck: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    this.router.params.subscribe(params => {this.id = params['id']})
    this.http.get<Tournament>(`${environment.apiTournamentUrl}/${this.id}`).subscribe(data => {this.tournament = data})
    this.http.get<any>(`${environment.apiTournamentUrl}/${this.id}/Player`).subscribe(data => {this.selectedPlayerList = data})
  }

  openDialog() {
    const dialogRef = this.dialog.open(OngoingTournamentPopupComponent);
    dialogRef.afterClosed().subscribe(result =>{
      console.log(result.firstName);
      this.addPlayerToList(result);
      this.http.post<any>(`${environment.apiTournamentUrl}/${this.id}/Player/${result.id}`, result).subscribe()
    })
  }

  openRollDialog() {
    const dialogRef = this.dialog.open(OngoingTournamentRollTablesPopupComponent, {panelClass: 'my-class'});

    dialogRef.afterClosed().subscribe(result =>{
      if(result){
        this.http.post<any>(`${environment.apiTournamentUrl}/${this.id}/Table/TablePlayer`, '').subscribe()
        this.urlRouter.navigateByUrl(`Ongoing-Tournament-Page/${this.id}/Tables`);
      }
    })
  }

  getPlayerDeck(): void{
    this.http.get<any>(`${environment.apiTournamentUrl}/${this.id}/Deck`).subscribe()
  }
  
  onFileUpload(event:Event, id: number){

    const playerdeck = (event.target as HTMLInputElement).files;
    const formData = new FormData();

    if(id){
      this.result = id.toString();
    }

    formData.append('Id', this.result);
    formData.append('Deck', playerdeck![0]);

    //this.playerToSend = player;
    this.http.put<Tournament>(`${environment.apiTournamentUrl}/${this.id}/TournamentPlayer`, formData).subscribe()
    
  }

  tournament!: Tournament;

  public addPlayerToList(i: any): void{
    this.selectedPlayerList.push(i);
  }

  playerToSend:TournamentPlayer[] = [];
  selectedPlayerList:TournamentPlayer[] = [];
}
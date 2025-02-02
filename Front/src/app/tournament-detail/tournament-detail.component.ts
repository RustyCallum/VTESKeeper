import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HomepageComponent } from '../homepage/homepage.component';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Table } from '../table-page/table-class/table-interface';
import { TablePlayer } from '../table-page/table-player-class/table-player-interface';

interface Player{
  name:string, 
  vekn:string, 
  VP:number, 
  GW:number, 
  table:number, 
  round:number
}

@Component({
  selector: 'app-tournament-detail',
  templateUrl: './tournament-detail.component.html',
  styleUrl: './tournament-detail.component.css',
})
export class TournamentDetailComponent{

  data: any;

  constructor(
    public tourny:HomepageComponent,
    public router: ActivatedRoute,
    public http: HttpClient 
  ) {}

  ngOnInit(): void {
    this.router.params.subscribe(params => 
      {this.id = params['id']})
  
    this.http.get<Table[]>(`${environment.apiTournamentUrl}/${this.id}/Table`).subscribe(data => this.tableList = data)
    this.http.get<TablePlayer[]>(`${environment.apiTournamentUrl}/${this.id}/Table/TablePlayer`).subscribe(data => this.playerList = data)
  }
  filter:string = "";
    
  filteredData = [];

  public getPlayerDeck(id:number, firstName:string, lastName:string){
    return this.http.get<any>(`${environment.apiTournamentUrl}/${this.id}/Player/Deck/${id}`, {responseType:'text' as 'json'} ).subscribe( response => {
      //let downloadName = response.headers.get('content-disposition')?.split(';')[1].split('=')[1];
      this.downloadFile(response, 'text/plain', firstName, lastName)
  });
  }

  downloadFile(data:any, type:string, fname:string, lname:string){
    let blob = new Blob([data], { type: type});
    let url = window.URL.createObjectURL(blob);
    let a = document.createElement('a');
    a.download=`Deck - ${fname} ${lname}.txt`;
    a.href = url;
    a.click();
  }

    //*************** JESLI LUDZIE BEDA CHCIELI ZEBY OPROCZ POBRANIA OTWIERALA SIE KARTA TO ODKOMENTUJ TEN KOD *************
    //let pwa = window.open(url);
    //if (!pwa || pwa.closed || typeof pwa.closed == 'undefined') {
      //alert( 'Please disable your Pop-up blocker and try again.');
  //}
  
  id!: number;
  name!: string;

  tableList: Table[] = [];
  playerList: TablePlayer[] = [];

  //playersList:Player[] = playerDetails;
}

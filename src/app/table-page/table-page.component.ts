import { Component } from '@angular/core';
import { TablePlayer } from './table-player-class/table-player-interface';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Table } from './table-class/table-interface';
import { ActivatedRoute } from '@angular/router';
import { PutTablePlayer } from './table-player-class/table-player-put-interface';
import { FinalistTable } from './finalist-table-class/finalist-table-class';
import { Observable } from 'rxjs';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';

@Component({
  selector: 'app-table-page',
  templateUrl: './table-page.component.html',
  styleUrl: './table-page.component.css',
})
export class TablePageComponent {
  id!: number;
 table:any;
 areFinalistsChosen!:boolean;

  constructor(private http: HttpClient, private router: ActivatedRoute){
  }

  ngOnInit(): void {
    this.router.params.subscribe(params => {this.id = params['id']})
    this.http.get<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table`).subscribe(data => {this.tableList = data});
    this.http.get<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table/TopPlayers`).subscribe((data:TablePlayer[]) => 
    {
      this.finalistsArray = data
      if(this.finalistsArray.length == 0){
        this.areFinalistsChosen = false;
      }
      else{
        this.areFinalistsChosen = true;
      }
    });
    this.http.get<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table/TablePlayer`).subscribe(data => {this.tablePlayers = data});
  }

  onKeyChangeVP(value:number, tableplayerid:number, tableid:number, nestedplayerid:number, seat:number, gw:number): void{
    console.log(tableplayerid, value, gw, seat, tableid, nestedplayerid);
    const body: PutTablePlayer = {id: tableplayerid, vp:value, gw: gw, seat: seat, tableId: tableid, playerId: nestedplayerid};

    this.http.put<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table/${tableid}`, body).subscribe()
    for(let i = 0; i < this.tablePlayers.length; i++){
      if(this.tablePlayers[i].id == tableplayerid){
        this.tablePlayers[i].vp = value;
      }
    }
  }

  onKeyChangeGW(value:number, tableplayerid:number, tableid:number, nestedplayerid:number, seat:number, vp:number): void{
    console.log(tableplayerid, vp, value, seat, tableid, nestedplayerid);
    const body: PutTablePlayer = {id: tableplayerid, vp:vp, gw:value, seat: seat, tableId: tableid, playerId: nestedplayerid};

    this.http.put<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table/${tableid}`, body).subscribe()
    for(let i = 0; i < this.tablePlayers.length; i++){
      if(this.tablePlayers[i].id == tableplayerid){
        this.tablePlayers[i].gw = value;
      }
    }
  }

  GetTournamentFinalistTable(): void {
    this.http.get<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table`).subscribe(data=> {this.tableList = data})
    this.http.get<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table/TopPlayers`).subscribe((data:TablePlayer[]) => {this.finalistsArray = data});
    console.log("hello")
  }

  ChooseFinalists(): void{
    this.http.post<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table/TopPlayers`, '').subscribe(data => 
    {
      this.finalistsArray = data
      this.tableList.push(this.finalistsArray[1].table);
      this.areFinalistsChosen = true;
    });
    //this.http.get<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table`).subscribe(data => 
    //{
        //this.tableList = data
        //this.areFinalistsChosen = true;
    //})
    console.log("done");
  }

  moveFinalistUp(index: number) {
    if(index >= 1){
      this.swap(this.finalistsArray, index, index-1)
      this.finalistsArray[index].seat = index+1;
      this.finalistsArray[index-1].seat = index;
      this.http.put<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table/${this.finalistsArray[index].tableId}`, this.finalistsArray[index]).subscribe()
      this.http.put<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table/${this.finalistsArray[index].tableId}`, this.finalistsArray[index-1]).subscribe()
    }
  }

  moveFinalistDown(index: number) {
    if(index < this.finalistsArray.length - 1){
      this.swap(this.finalistsArray, index, index+1)
      this.finalistsArray[index+1].seat = index+2;
      this.finalistsArray[index].seat = index+1;
      this.http.put<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table/${this.finalistsArray[index].tableId}`, this.finalistsArray[index]).subscribe()
      this.http.put<any[]>(`${environment.apiTournamentUrl}/${this.id}/Table/${this.finalistsArray[index].tableId}`, this.finalistsArray[index+1]).subscribe()
    }
  }

  private swap(array:any[], x:any, y:any){
    var b = array[x];
    array[x] = array[y];
    array[y] = b;
  }

  finalistsArray: TablePlayer[] = [];
  finalistTable: Table[] = [];
  tablePlayers: TablePlayer[] = [];
  tableList: Table[] = [];
}

import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-ongoing-tournament-popup',
  templateUrl: './ongoing-tournament-popup.component.html',
  styleUrls: ['./ongoing-tournament-popup.component.css'] // poprawione: styleUrls
})
export class OngoingTournamentPopupComponent implements OnInit {
  vekn!: number;
  firstName!: string;
  city!: string;

  current_selected!: string;

  // Zmienna do przechowywania nowego gracza
  newPlayer = {
    vekn: '',
    firstName: '',
    lastName: '',
    playerCity: ''
  };

  playersList: any[] = []; // Początkowo pusta lista graczy

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    // Pobranie danych graczy z API
    this.http.get<any[]>(`${environment.apiPlayerUrl}`).subscribe(data => {
      this.playersList = data;
    });
  }

  // Funkcja do dodawania nowego gracza
  addPlayer(): void {
    // Dodanie nowego gracza do listy
    this.playersList.push({ ...this.newPlayer });

    // Wyczyszczenie formularza
    this.newPlayer = {
      vekn: '',
      firstName: '',
      lastName: '',
      playerCity: ''
    };
  }
}

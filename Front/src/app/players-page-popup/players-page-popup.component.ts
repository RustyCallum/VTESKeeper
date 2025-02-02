import { Component, Inject, Injectable } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Players } from '../players-page/players.component';

@Component({
  selector: 'app-players-page-popup',
  templateUrl: './players-page-popup.component.html',
  styleUrl: './players-page-popup.component.css'
})
@Injectable()
export class PlayersPagePopupComponent {
  constructor(public dialog: MatDialogRef<PlayersPagePopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Players) {}

    
}


import { Component, Inject, Injectable } from '@angular/core';
import { FormGroup, FormControl, Form, FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { HomepageComponent } from '../homepage/homepage.component';
import { Tournament } from '../homepage/tournament';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-create-tournament',
  templateUrl: './create-tournament-popup.component.html',
  styleUrl: './create-tournament-popup.component.css',
})

@Injectable()
export class CreateTournamentPopupComponent {

  constructor(public dialog: MatDialogRef<CreateTournamentPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Tournament
  ) {
  }
}


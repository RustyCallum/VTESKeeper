import { Component, Inject, Injectable, inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA, MatSnackBar, MatSnackBarRef } from '@angular/material/snack-bar';
import { MatIconModule } from '@angular/material/icon';

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.css'
})
export class NotificationComponent {

  type!: string
  message!: string

  constructor(private snackBar: MatSnackBar) { }

  showNotification(passedMessage: string, messageType: 'success' | 'error'){
    this.type = messageType
    this.message = passedMessage

    this.snackBar.openFromComponent(NotificationPopup, {
      data:{
        message: passedMessage,
        messageType: messageType
      },
      horizontalPosition: 'center',
      verticalPosition: 'bottom',
      panelClass: messageType,
    })
  }
}

@Component({
  templateUrl:'notification-popup.html',
  styleUrl:'notification-popup.css',
  standalone: true,
  imports:[MatIconModule]
})
export class NotificationPopup{

  constructor(@Inject(MAT_SNACK_BAR_DATA) public data: any){

  }
  snackBarRef = inject(MatSnackBarRef);
}

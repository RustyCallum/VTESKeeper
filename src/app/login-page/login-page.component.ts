import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { JwtModule } from "@auth0/angular-jwt";
import { NotificationComponent } from '../notification/notification.component';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {
  constructor(private http:HttpClient, private fb: FormBuilder, private notification: NotificationComponent)
  {
    this.loginForm = this.fb.group({
      username:['', Validators.required],
      password:['', Validators.required]
    })
  }

  loginForm!: FormGroup

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username:['', Validators.required],
      password:['', Validators.required]
    })
    
  }

  login(loginObj: any){
    this.http.post<any>(`https://localhost:7272/api/User/Login`,loginObj.value,{responseType:'text' as 'json'}).subscribe(token =>
    {
      this.notification.showNotification("Logowanie pomyślne", 'success')
      localStorage.setItem('id_token', token);
    },
    error => {
      this.notification.showNotification("Nie udało się zalogować", 'error')
    }
    );
  }

  
}

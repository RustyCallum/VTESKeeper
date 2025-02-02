import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatTabsModule } from '@angular/material/tabs';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomepageComponent } from './homepage/homepage.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { LeaguePageComponent } from './league-page/league-page.component';
import { FormsModule } from '@angular/forms';
import { TableFilterPipe } from './homepage/table-filter.pipe';
import { TableSizePipe } from './homepage/table-size-filter.pipe';
import { TournamentDetailComponent } from './tournament-detail/tournament-detail.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { NameFilterPipe } from './homepage/search-filter.pipe';
import { LeagueFilterPipe } from './league-page/search-filter.pipe';
import { allTournamentFilterPipe } from './tournament-detail/search-filter.pipe';
import { CreateTournamentPopupComponent } from './create-tournament-popup/create-tournament-popup.component';
import { OngoingTournamentPageComponent } from './ongoing-tournament-page/ongoing-tournament-page.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {ReactiveFormsModule} from '@angular/forms';
import { OngoingTournamentPopupComponent } from './ongoing-tournament-popup/ongoing-tournament-popup.component';
import {MatListModule} from '@angular/material/list';
import { PlayersPageComponent } from './players-page/players.component';
import { PlayerFilterPipe } from './players-page/player-filter.pipe';
import { PlayersPagePopupComponent } from './players-page-popup/players-page-popup.component';
import { OngoingTournamentRollTablesPopupComponent } from './ongoing-tournament-roll-tabels-popup/ongoing-tournament-roll-tabels-popup.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core'; 
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { TablePageComponent } from './table-page/table-page.component';
import { MatIconModule } from '@angular/material/icon';
import { AuthInterceptor } from './AuthenticationInterceptor';
import { JwtHelperService, JWT_OPTIONS  } from '@auth0/angular-jwt';
import { NotificationComponent } from './notification/notification.component';
import { MatSnackBarModule, MatSnackBarRef} from '@angular/material/snack-bar';
import { ArchiveTournamentComponent } from './archive-tournament/archive-tournament.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomepageComponent,
    LoginPageComponent,
    LeaguePageComponent,
    TableFilterPipe,
    TableSizePipe,
    TournamentDetailComponent,
    NameFilterPipe,
    LeagueFilterPipe,
    PlayerFilterPipe,
    allTournamentFilterPipe,
    CreateTournamentPopupComponent,
    OngoingTournamentPageComponent,
    OngoingTournamentPopupComponent,
    PlayersPageComponent,
    PlayersPagePopupComponent,
    OngoingTournamentRollTablesPopupComponent,
    TablePageComponent,
    NotificationComponent,
    ArchiveTournamentComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NoopAnimationsModule,
    MatTabsModule,
    MatSlideToggleModule,
    BrowserAnimationsModule,
    MatDialogModule, 
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatListModule,
    MatDatepickerModule,
    MatNativeDateModule,
    HttpClientModule,
    MatIconModule,
    MatSnackBarModule,
  ],
  providers: [HomepageComponent, 
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi:true},
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS }, 
    JwtHelperService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

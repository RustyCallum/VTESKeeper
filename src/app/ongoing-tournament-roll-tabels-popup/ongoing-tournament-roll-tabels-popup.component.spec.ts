import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OngoingTournamentRollTablesPopupComponent } from './ongoing-tournament-roll-tabels-popup.component';

describe('OngoingTournamentRollTabelsPopupComponent', () => {
  let component: OngoingTournamentRollTablesPopupComponent;
  let fixture: ComponentFixture<OngoingTournamentRollTablesPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OngoingTournamentRollTablesPopupComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OngoingTournamentRollTablesPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

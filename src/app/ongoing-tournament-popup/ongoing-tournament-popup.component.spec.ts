import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OngoingTournamentPopupComponent } from './ongoing-tournament-popup.component';

describe('OngoingTournamentPopupComponent', () => {
  let component: OngoingTournamentPopupComponent;
  let fixture: ComponentFixture<OngoingTournamentPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OngoingTournamentPopupComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OngoingTournamentPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

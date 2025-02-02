import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OngoingTournamentPageComponent } from './ongoing-tournament-page.component';

describe('OngoingTournamentPageComponent', () => {
  let component: OngoingTournamentPageComponent;
  let fixture: ComponentFixture<OngoingTournamentPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OngoingTournamentPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OngoingTournamentPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
